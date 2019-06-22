using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XamADALMultiResources.Services
{
    public interface ILoginProvider
    {
        Task<string> LoginAsync();
        Task LogOutAsync();

    }
}
