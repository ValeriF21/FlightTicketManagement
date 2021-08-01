using FlightTicketManagementEntites;
using System;
using System.Collections.Generic;

namespace FlightTicketManagementAPI.IServices
{
    public interface IRemarkService
    {
        List<Remark> Gets();

        Remark Get(int id);

        string Save(Remark oRemark);

        void Update(int id, Remark oRemark);

        void Delete(int id);
    }
}
