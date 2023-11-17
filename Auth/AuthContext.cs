using Microsoft.EntityFrameworkCore;
using TodoStudent.Auth.Entities;

namespace TodoStudent.Auth;

public class AuthContext: DbContext
{
    public DbSet<UserEntity> Users => Set<UserEntity>();
    
    public AuthContext()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public AuthContext(DbContextOptions<AuthContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
}