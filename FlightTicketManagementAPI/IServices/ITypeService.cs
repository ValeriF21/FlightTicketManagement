using System;
using System.Collections.Generic;
using Type = FlightTicketManagementEntites.Type;

namespace FlightTicketManagementAPI.IServices
{
    public interface ITypeService
    {
        List<Type> Gets();

        Type Get(int id);

        string Save(Type oType);

        void Update(int id, Type oType);

        void Delete(int id);
    }
}
