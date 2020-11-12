using System.Threading.Tasks;
using SCDFrontend.Models;
using System.Collections.Generic;
using System.Net.Http;
public interface IApiConnector
{
    Task<List<Installation>> GetInstallations();

    Task<Installation> GetInstallation(string name);

    Task<InstallationRoot> GetLatestJson(string name);

    Task<HttpResponseMessage> CreateCopy(CopyInst copy);

    Task<List<Client>> GetClients();

    Task<List<Subscription>> GetSubscriptions();

    Task<HttpResponseMessage> Start(string name);

    Task<HttpResponseMessage> Stop(string name);

}