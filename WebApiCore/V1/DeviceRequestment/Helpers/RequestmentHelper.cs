using WebApiCore.V1.DeviceRequestment.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApiCore.V1.DeviceRequestment.Helpers
{
    public class RequestmentHelper
    {
        public async Task<object> AdminRequestGet(DataContext context, string id)
        {
            var Requestments = await context.Requestments.FromSqlRaw("EXEC dbo.sp_docSign_adminRequest_owner {0}", id).ToListAsync();

            var RequestmentItems = await context.RequestmentItems.FromSqlRaw("EXEC dbo.sp_docSign_adminRequest_item {0}", id).ToListAsync();

            Requestments.Where(c => c.SdmId == id).ToList().ForEach(cc => cc.RequestmentItems = RequestmentItems);

            return Requestments;
        }

        public async Task<object> UserRequestGet(DataContext context, string id)
        {
            var Requestments = await context.Requestments.FromSqlRaw("EXEC dbo.sp_docSign_userRequest_owner {0}", id).ToListAsync();

            var RequestmentItems = await context.RequestmentItems.FromSqlRaw("EXEC dbo.sp_docSign_userRequest_item {0}", id).ToListAsync();

            Requestments.Where(c => c.SdmId == id).ToList().ForEach(cc => cc.RequestmentItems = RequestmentItems);

            return Requestments;
        }
    }
}
