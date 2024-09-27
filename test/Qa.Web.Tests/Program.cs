using Microsoft.AspNetCore.Builder;
using Qa;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<QaWebTestModule>();

public partial class Program
{
}
