using Microsoft.EntityFrameworkCore;
using TodoStudent.Auth.Entities;

namespace TodoStudent.Auth;

public class AuthContext: DbContext
{
    public DbSet<UserEntity> Users => Set<UserEntity>();
}