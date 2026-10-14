public enum AccountType
{
    Default = Permission.None,
    Guest = Permission.Read,
    User = Permission.Read | Permission.Write,
    Moderator = Permission.All
}

[Flags]
public enum Permission
{
    None = 0,
    Read = 1, 
    Write = 2,
    Delete = 4,
    All = Read | Write | Delete,
}

static class Permissions
{
    public static Permission Default(AccountType accountType) 
        => typeof(AccountType).IsEnumDefined(accountType) ? (Permission) accountType : Permission.None;

    public static Permission Grant(Permission current, Permission grant) => current | grant;

    public static Permission Revoke(Permission current, Permission revoke) => (Permission)(current & ~revoke);

    public static bool Check(Permission current, Permission check) => (check & current) == check;
}
