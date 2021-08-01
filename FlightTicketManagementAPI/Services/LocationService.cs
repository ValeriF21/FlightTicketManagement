using Dapper;
using FlightTicketManagementAPI.Common;
using FlightTicketManagementAPI.IServices;
using FlightTicketManagementEntites;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace FlightTicketManagementAPI.Services
{
    public class LocationService : ILocationService
    {
        Location _oLocation = new Location();
        List<Location> _oLocations = new List<Location>();
        GenericService gService = new GenericService(); 

        public List<Location> Gets()
        {
            _oLocations = new List<Location>();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@pCode", null);

                var oLocations = gService.Execute_Queries<Location>("Get_Location", CommandType.StoredProcedure, parameters).ToList();

                if (oLocations != null && oLocations.Count() > 0)
                {
                    _oLocations = oLocations;
                }

                return _oLocations;
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Location Get(string pCode)
        {
            try
            {
                _oLocation = new Location();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@pCode", pCode);

                var oLocations = gService.Execute_Queries<Location>("Get_Location", CommandType.StoredProcedure, parameters);

                if (oLocations != null && oLocations.Count() > 0)
                {
                    _oLocation = oLocations.SingleOrDefault();
                }

                return _oLocation;
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Save(Location oLocation)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@pCode", oLocation.Code);
                parameters.Add("@pAirport", oLocation.Airport);
                parameters.Add("@pCountry", oLocation.Country);
                var oLocations = gService.Execute_Queries<Location>("Insert_New_Location", CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(string pCode, Location oLocation)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@pCode", pCode);
                parameters.Add("@pAirport", oLocation.Airport);
                parameters.Add("@pCountry", oLocation.Country);

                var oLocations = gService.Execute_Queries<Location>("Update_Location", CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(string pCode)
        {
            try
            {
                DynamicParameters parametrs = new DynamicParameters();
                parametrs.Add("@pCode", pCode);

                var oLocations = gService.Execute_Queries<Location>("Delete_Location", CommandType.StoredProcedure, parametrs);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
