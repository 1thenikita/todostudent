using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoStudent.Auth;
using TodoStudent.Auth.Entities;
using TodoStudent.Shared.EditModels;
using TodoStudent.Shared.Interfaces;
using TodoStudent.Shared.Extensions;

namespace TodoStudent.Server.Services;

public class UserService : IService<UserEntity, UserEditModel, Guid>
{
    private AuthContext Context;
    private IMapper Mapper;

    public UserService(AuthContext context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
    }

    public List<UserEntity> GetAll()
    {
        return Context.Users.AsNoTracking().ToList();
    }

    public string GetAllHash()
    {
        return GetAll().ToHashSHA256();
    }

    public List<UserEntity> GetAllFull()
    {
        return Context.Users.AsNoTracking()
            .ToList();
    }

    public string GetAllFullHash()
    {
        return GetAllFull().ToHashSHA256();
    }

    public async Task<UserEntity?> GetByID(Guid id)
    {
        return await Context.Users.AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == id);
    }

    public async Task<string> GetByIDHash(Guid id)
    {
        return (await GetByID(id)).ToHashSHA256();
    }

    public async Task<UserEntity?> GetByIDFull(Guid id)
    {
        return await Context.Users.AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == id);
    }

    public async Task<string> GetByIDFullHash(Guid id)
    {
        return (await GetByIDFull(id)).ToHashSHA256();
    }

    public UserEntity? GetByLogin(string login)
    {
        return Context.Users.AsNoTracking().AsEnumerable().FirstOrDefault(x =>
            (x.Login?.Equals(login, StringComparison.OrdinalIgnoreCase) ?? false));
    }

    public async Task<UserEntity?> Update(Guid id, UserEditModel editModel)
    {
        var entity = Mapper.Map<UserEntity>(editModel);
        entity.ID = id;

        // TODO проверки

        if (!string.IsNullOrWhiteSpace(editModel.Password))
        {
            entity.PasswordHash = editModel.Password.ToHashSHA256();
        }
        else
        {
            Context.Entry(entity).Property(x => x.PasswordHash).IsModified = false;
        }

        Context.Attach(entity);
        Context.Entry(entity).State = EntityState.Modified;

        await Context.SaveChangesAsync();

        return entity;
    }

    public async Task<UserEntity?> Create(UserEditModel editModel)
    {
        var entity = Mapper.Map<UserEntity>(editModel);
        // TODO проверки

        if (!string.IsNullOrWhiteSpace(editModel.Password))
        {
            entity.PasswordHash = editModel.Password.ToHashSHA256();
        }
        else
        {
            // TODO
        }

        Context.Add(entity);

        await Context.SaveChangesAsync();

        return entity;
    }

    public async Task<bool> Delete(Guid id)
    {
        var entity = await Context.Users.FindAsync(id);
        if (entity == null)
        {
            return false;
        }

        Context.Remove(entity);
        await Context.SaveChangesAsync();

        return true;
    }
}