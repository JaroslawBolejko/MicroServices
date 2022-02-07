namespace MicroServicesWebApi.SyncDataServices.Http;

public interface ICommandDataClient
{
    Task SendPlatformToCommand(PlatformReadDto plat);
}