namespace ShopSuite.Shared
{
    public static class UserRole
    {
        public const int User = 1;
        public const int Admin = 2;
        public const int SuperAdmin = 3;
        public const string UserName = "User";
        public const string AdminName = "Admin";
        public const string SuperAdminName = "SuperAdmin";

        public static string GetRoleName(int roleId)
        {
            return roleId switch
            {
                User => UserName,
                Admin => AdminName,
                SuperAdmin => SuperAdminName,
                _ => string.Empty
            };
        }
    }
}