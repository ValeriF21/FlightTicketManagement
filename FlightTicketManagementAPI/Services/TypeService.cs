using Dapper;
using FlightTicketManagementAPI.Common;
using FlightTicketManagementAPI.IServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Type = FlightTicketManagementEntites.Type;

namespace FlightTicketManagementAPI.Services
{
    public class TypeService : ITypeService
    {
        Type _oType = new Type();
        List<Type> _oTypes = new List<Type>();
        GenericService gService = new GenericService();

        public List<Type> Gets()
        {
            _oTypes = new List<Type>();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@pType_ID", null);

                var oTypes = gService.Execute_Queries<Type>("Get_Type", CommandType.StoredProcedure, parameters).ToList();

                if (oTypes != null && oTypes.Count() > 0)
                {
                    _oTypes = oTypes;
                }

                return _oTypes;
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Type Get(int id)
        {
            try
            {
                _oType = new Type();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@pType_ID", id);

                var oTypes = gService.Execute_Queries<Type>("Get_Type", CommandType.StoredProcedure, parameters);

                if (oTypes != null && oTypes.Count() > 0)
                {
                    _oType = oTypes.SingleOrDefault();
                }

                return _oType;
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public string Save(Type oType)
        {
            SqlConnection con = new SqlConnection(Global.ConnectionString);

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Insert_New_Type";
                cmd.Parameters.Add("@pDescription", SqlDbType.VarChar).Value = oType.Description;
                cmd.Parameters.Add("@pBase_Multiplication", SqlDbType.Float).Value = oType.Base_Multiplication;
                cmd.Parameters.Add("@pBase_Addition", SqlDbType.Float).Value = oType.Base_Addition;
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

        public void Update(int id, Type oType)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@pType_ID", id);
                parameters.Add("@pDescription", oType.Description);
                parameters.Add("@pBase_Multiplication", oType.Base_Multiplication);
                parameters.Add("@pBase_Addition", oType.Base_Addition);

                var oTypes = gService.Execute_Queries<Type>("Update_Type", CommandType.StoredProcedure, parameters);
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
                parametrs.Add("@pType_ID", id);

                var oTypes = gService.Execute_Queries<Type>("Delete_Type", CommandType.StoredProcedure, parametrs);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
