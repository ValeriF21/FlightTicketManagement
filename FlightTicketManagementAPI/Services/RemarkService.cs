using Dapper;
using FlightTicketManagementAPI.Common;
using FlightTicketManagementAPI.IServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using FlightTicketManagementEntites;

namespace FlightTicketManagementAPI.Services
{
    public class RemarkService : IRemarkService
    {
        Remark _oRemark = new Remark();
        List<Remark> _oRemarks = new List<Remark>();
        GenericService gService = new GenericService();

        public List<Remark> Gets()
        {
            _oRemarks = new List<Remark>();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@pRemark_ID", null);

                var oRemarks = gService.Execute_Queries<Remark>("Get_Remark", CommandType.StoredProcedure, parameters).ToList();

                if (oRemarks != null && oRemarks.Count() > 0)
                {
                    _oRemarks = oRemarks;
                }

                return _oRemarks;
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Remark Get(int id)
        {
            try
            {
                _oRemark = new Remark();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@pRemark_ID", id);

                var oRemarks = gService.Execute_Queries<Remark>("Get_Remark_By_ID", CommandType.StoredProcedure, parameters);

                if (oRemarks != null && oRemarks.Count() > 0)
                {
                    _oRemark = oRemarks.SingleOrDefault();
                }

                return _oRemark;
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public string Save(Remark oRemark)
        {
            SqlConnection con = new SqlConnection(Global.ConnectionString);

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Insert_New_Remark";
                cmd.Parameters.Add("@pDescription", SqlDbType.VarChar).Value = oRemark.Description;
                cmd.Parameters.Add("@pType_ID", SqlDbType.Int).Value = oRemark.Type_ID;
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

        public void Update(int id, Remark oRemark)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@pDescription", oRemark.Description);
                parameters.Add("@pType_ID", oRemark.Type_ID);
                parameters.Add("@pRemark_ID", id);

                var oRemarks = gService.Execute_Queries<Remark>("Update_Remark", CommandType.StoredProcedure, parameters);
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
                parametrs.Add("@pRemark_ID", id);

                var oRemarks = gService.Execute_Queries<Remark>("Delete_Remark", CommandType.StoredProcedure, parametrs);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
