using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

namespace ASSAS_DataAccessLayer
{
    public class Users
    {

        string DBName = "ASSAC_BnDb";
        public int Login(string username, string pwd, string Databasename)
        {
                    
            try
            {

                Database db = DatabaseFactory.CreateDatabase(DBName);
                Object[] param = new Object[] {  
                                                 username,
                                                 pwd
                                                };
                return Convert.ToString(db.ExecuteScalar("sp_Login", param)).Length;
            }
            catch
            {

                return 0;
            }
        }

        public DataSet Get_Appts(String unit_name)
        {

            try
            {

                Database db = DatabaseFactory.CreateDatabase(DBName);
                Object[] param = new Object[] {  
                                                 unit_name
                                                };
                return db.ExecuteDataSet ("sp_GetAppointments", param);
                
            }
            catch
            {

                return null;
            }
        }

        public bool  Add_Appts(string appt, int can_approve, int next, string processing_time)
        {
            try
            {

                Database db = DatabaseFactory.CreateDatabase(DBName);
                Object[] param = new Object[] {  
                                                 appt, can_approve, next, processing_time
                                                };
                db.ExecuteScalar("sp_AddAppointment", param);
                 return true;

            }
            catch
            {

                return false;
            }
        }

        public bool AddNewUser(string ArmyNo, string Name, int appoitmentid, string Pass, string DBNames)
        {
            try
            {
                
                Database db = DatabaseFactory.CreateDatabase(DBName);
                Object[] param = new Object[] { 
                                                  ArmyNo,
                                                  Name,
                                                  appoitmentid, 
                                                  Pass,
                                                  ArmyNo+Name
                                                };
                db.ExecuteScalar("sp_AddNewUser", param);

            }
            catch (Exception ex)
            {
             
                return false;
            }
            return true;
        }
    }
}
