using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FinalProject1_013.Models
{
    public class PaymentDetailContext
    {
        public string ConnectionString { get; set; }

        public PaymentDetailContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<PaymentDetailItem> GetAllPaymentDetails()
        {
            List<PaymentDetailItem> list = new List<PaymentDetailItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM payment", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new PaymentDetailItem()
                        {
                            paymentDetailId = reader.GetInt32("paymentDetailId"),
                            cardOwnerName = reader.GetString("cardOwnerName"),
                            cardNumber = reader.GetString("cardNumber"),
                            expirationDate = reader.GetString("expirationDate"),
                            securityCode = reader.GetString("securityCode")
                        });
                    }
                }
            }
            return list;
        }

        public List<PaymentDetailItem> GetPaymentDetail(string id)
        {
            List<PaymentDetailItem> list = new List<PaymentDetailItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM payment WHERE paymentDetailId=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new PaymentDetailItem()
                        {
                            paymentDetailId = reader.GetInt32("paymentDetailId"),
                            cardOwnerName = reader.GetString("cardOwnerName"),
                            cardNumber = reader.GetString("cardNumber"),
                            expirationDate = reader.GetString("expirationDate"),
                            securityCode = reader.GetString("securityCode")
                        });
                    }
                }
            }
            return list;
        }

        public string DeletePaymentDetail(string id)
        {
            List<PaymentDetailItem> list = new List<PaymentDetailItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM payment WHERE paymentDetailId=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                
                if(cmd.ExecuteNonQuery() == 1){
                    return "ID " + id +  " Deleted";
                }
                else{
                    return "ID " + id + " Not Found";
                }
                // using (MySqlDataReader reader = cmd.ExecuteReader())
                // {
                //     while (reader.Read())
                //     {
                //         list.Add(new PaymentDetailItem()
                //         {
                //             paymentDetailId = reader.GetInt32("paymentDetailId"),
                //             cardOwnerName = reader.GetString("cardOwnerName"),
                //             cardNumber = reader.GetString("cardNumber"),
                //             expirationDate = reader.GetString("expirationDate"),
                //             securityCode = reader.GetString("securityCode")
                //         });
                //     }
                // }
                
            }
            // return list;
        }

        public List<PaymentDetailItem> InsertPaymentDetail(PaymentDetailItem paymentDetail)
        {
            List<PaymentDetailItem> list = new List<PaymentDetailItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("INSERT INTO payment(cardOwnerName, cardNumber, expirationDate, securityCode) VALUES('" 
                + paymentDetail.cardOwnerName + "','"
                + paymentDetail.cardNumber + "','" 
                + paymentDetail.expirationDate + "','" 
                + paymentDetail.securityCode +"')", conn);
                // cmd.Parameters.AddWithValue("@name", name);
                // cmd.Parameters.AddWithValue("@genre", genre);
                // cmd.Parameters.AddWithValue("@duration", duration);
                // cmd.Parameters.AddWithValue("@releasedate", releasedate);
                if(cmd.ExecuteNonQuery() == 1){
                    MySqlCommand cmd_get = new MySqlCommand("SELECT * FROM payment ORDER BY paymentDetailId DESC LIMIT 1", conn);
                    
                    using (MySqlDataReader reader = cmd_get.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new PaymentDetailItem()
                            {
                                paymentDetailId = reader.GetInt32("paymentDetailId"),
                                cardOwnerName = reader.GetString("cardOwnerName"),
                                cardNumber = reader.GetString("cardNumber"),
                                expirationDate = reader.GetString("expirationDate"),
                                securityCode = reader.GetString("securityCode")
                            });
                        }
                    }
                    return list;
                }
                return list;
            }
           
        }

        public List<PaymentDetailItem> UpdatePaymentDetail(string id, PaymentDetailItem paymentDetail)
        {
            List<PaymentDetailItem> list = new List<PaymentDetailItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("UPDATE payment SET cardOwnerName='" + paymentDetail.cardOwnerName 
                +"', cardNumber='" + paymentDetail.cardNumber 
                + "', expirationDate='" + paymentDetail.expirationDate 
                + "', securityCode='" + paymentDetail.securityCode 
                + "' WHERE paymentDetailId=" + id, conn);
                if(cmd.ExecuteNonQuery() == 1){
                    MySqlCommand cmd_get = new MySqlCommand("SELECT * FROM payment WHERE paymentDetailId=@id", conn);
                    cmd_get.Parameters.AddWithValue("@id", id);
                    using (MySqlDataReader reader = cmd_get.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new PaymentDetailItem()
                            {
                                paymentDetailId = reader.GetInt32("paymentDetailId"),
                                cardOwnerName = reader.GetString("cardOwnerName"),
                                cardNumber = reader.GetString("cardNumber"),
                                expirationDate = reader.GetString("expirationDate"),
                                securityCode = reader.GetString("securityCode")
                            });
                        }
                    }
                    return list;
                }
                return list;
            }
            
        }

    }
}
