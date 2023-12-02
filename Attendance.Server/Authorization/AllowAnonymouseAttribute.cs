namespace Attendance.Server.Authorization;

[AttributeUsage(AttributeTargets.Method)]
public class AllowAnonymouseAttribute : Attribute { }