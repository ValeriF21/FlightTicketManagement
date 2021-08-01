using Dapper;
using FlightTicketManagementAPI.Common;
using FlightTicketManagementAPI.IServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using FlightTicketManagementEntites;
using FlightTicketManagementEntities;
using log4net;

namespace FlightTicketManagementAPI.Services
{
    public class FlightService : IFlightService
    {
        List<Flight> _oFlights = new List<Flight>();
        GenericService gService = new GenericService();

        public List<Regular> Gets()
        {
            var _oFlights = new List<Regular>();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@pFlight_ID", null);

                var oFlights = gService.Execute_Queries<Regular>("Get_Full_Flight_Data", CommandType.StoredProcedure, parameters).ToList();

                if (oFlights != null && oFlights.Count() > 0)
                {
                    _oFlights = oFlights;
                }

                return _oFlights;
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public FullFlight Get(int id)
        {
            try
            {
               var _oFlight = new FullFlight();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@pFlight_ID", id);

                var oFlights = gService.Execute_Queries<FullFlight>("Get_Full_Flight_Data", CommandType.StoredProcedure, parameters);

                if (oFlights != null && oFlights.Count() > 0)
                {
                    _oFlight = oFlights.SingleOrDefault();
                }

                return _oFlight;
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public string Save(Flight oFlight)
        {
            SqlConnection con = new SqlConnection(Global.ConnectionString);

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Insert_New_Flight";
                cmd.Parameters.Add("@pStartingPoint", SqlDbType.VarChar).Value = oFlight.StartingPoint;
                cmd.Parameters.Add("@pDestination", SqlDbType.VarChar).Value = oFlight.Destination;
                cmd.Parameters.Add("@pStartingPoint_Departure", SqlDbType.DateTime).Value = oFlight.StartingPoint_Departure.ToString("yyyy-MM-ddTHH:mm:ss");
                cmd.Parameters.Add("@pStartingPoint_Arrival", SqlDbType.DateTime).Value = oFlight.StartingPoint_Arrival.ToString("yyyy-MM-ddTHH:mm:ss");
                cmd.Parameters.Add("@pDestination_Departure", SqlDbType.DateTime).Value = oFlight.Destination_Departure.ToString("yyyy-MM-ddTHH:mm:ss");
                cmd.Parameters.Add("@pDestination_Arrival", SqlDbType.DateTime).Value = oFlight.Destination_Arrival.ToString("yyyy-MM-ddTHH:mm:ss");
                cmd.Parameters.Add("@pBase_Price", SqlDbType.VarChar).Value = oFlight.Base_Price;
                cmd.Parameters.Add("@pType_ID", SqlDbType.Int).Value = oFlight.Type_ID;
                cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                return cmd.Parameters["@id"].Value.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public void Update(int id, Flight oFlight)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@pID", id);
                parameters.Add("@pStartingPoint", oFlight.StartingPoint);
                parameters.Add("@pDestination", oFlight.Destination);
                parameters.Add("@pStartingPoint_Departure", oFlight.StartingPoint_Departure);
                parameters.Add("@pStartingPoint_Arrival", oFlight.StartingPoint_Arrival);
                parameters.Add("@pDestination_Departure", oFlight.Destination_Departure);
                parameters.Add("@pDestination_Arrival", oFlight.Destination_Arrival);
                parameters.Add("@pBase_Price", oFlight.Base_Price);
                parameters.Add("@pType_ID", oFlight.Type_ID);

                var oFlights = gService.Execute_Queries<Flight>("Update_Flight", CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                DynamicParameters parametrs = new DynamicParameters();
                parametrs.Add("@pFlight_ID", id);

                var oFlights = gService.Execute_Queries<Flight>("Delete_Flight", CommandType.StoredProcedure, parametrs);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
