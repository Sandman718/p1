namespace DL;
using SignUp;
using Microsoft.Data.SqlClient;

/*To connect my aws DB I need to use ADO.net (frameWork?)
to with data in SQL
*/


public class DataBaseRepos:InterRepos
{
    private string _connectionString;

    public DataBaseRepos() {
          _connectionString = File.ReadAllText("connectionString.txt");
    }
    public DataBaseRepos(string connectionString) {
        _connectionString = File.ReadAllText("connectionString.txt");
        Console.WriteLine("");
        Console.WriteLine("**DataBase Repos. Constructor running w/connection string**");
        Console.WriteLine(_connectionString);
        Console.WriteLine("");
    }
    public void AddSignUpCustomer(SignUpCustomer addCustomers)
    {
       //start here
      using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        string sqlCmd = "INSERT INTO Customer (ID, name, age, state) VALUES (@ID, @Name, @Age, @State)"; 
        using SqlCommand cmdAddUser= new SqlCommand(sqlCmd, connection);
        //Adding paramaters
        Random rnd = new Random();
        int customerid = rnd.Next(100000);
        cmdAddUser.Parameters.AddWithValue("@ID",customerid);
        cmdAddUser.Parameters.AddWithValue("@Name", addCustomers.name);
        cmdAddUser.Parameters.AddWithValue("@State", addCustomers.state);
        cmdAddUser.Parameters.AddWithValue("@Age", addCustomers.age);

        //Executing command
        cmdAddUser.ExecuteNonQuery();
        connection.Close();



    }

    public List<SignUpCustomer> getCustomers()
    {
       List<SignUpCustomer> allCustomers = new List<SignUpCustomer>();
       using(SqlConnection connection =  new SqlConnection(_connectionString)) {

           connection.Open();

            //query to the DB
           string queryInfo =  "SELECT * from Customer";
           //use sql command use the query to get info from DB
           using(SqlCommand cmd = new SqlCommand(queryInfo, connection)) {
               using(SqlDataReader reader = cmd.ExecuteReader()) {
                   
                   while(reader.Read())
                   { 
                       SignUpCustomer customer = new SignUpCustomer();
                       customer.customerNum=reader.GetInt32(0);
                       customer.name=reader.GetString(1); 
                        customer.state=reader.GetString(2);
                       customer.age=reader.GetInt32(3);
                       
                       allCustomers.Add(customer);
                       //output what's in that column
                       Console.WriteLine(reader.GetInt32(0));
                   }
               }
           }
           connection.Close();
          

       }
        return  allCustomers;
    }
}//end class