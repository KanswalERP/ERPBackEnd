using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NtierMvc.Common;
using NtierMvc.DataAccess.Common;
using NtierMvc.Model.Account;

namespace NtierMvc.DataAccess
{
    /// <summary>
    /// Purpose: Data Access Repository Class [LoginRepository] for the table [HR].[Login].
    /// </summary>
    public class LoginRepository : IRepository<LoginEntity>, IDisposable
    {
        #region Class Declarations

        private LoggingHandler _loggingHandler;
        private DataHandler _dataHandler;
        private ConfigurationHandler _configurationHandler;
        private DbProviderFactory _dbProviderFactory;
        private string _connectionString;
        private string _connectionProvider;
        private int _errorCode, _rowsAffected;
        private bool _bDisposed;

        #endregion

        #region Class Methods

        public bool Insert(LoginEntity entity)
        {
            try
            {
                var sb = new StringBuilder();
                sb.Append("SET DATEFORMAT DMY; ");
                sb.Append("INSERT [HR].[Login] ");
                sb.Append("( ");
                sb.Append("[Id], ");
                sb.Append("[Name], ");
                sb.Append("[Age], ");
                sb.Append("[HiringDate], ");
                sb.Append("[GrossSalary], ");
                sb.Append("[ModifiedDate] ");
                sb.Append(") ");
                sb.Append("VALUES ");
                sb.Append("( ");
                sb.Append(" @intId, ");
                sb.Append(" @chnName, ");
                sb.Append(" @intAge, ");
                sb.Append(" @dtmHiringDate, ");
                sb.Append(" @decGrossSalary, ");
                sb.Append(" ISNULL(@dtmModifiedDate, (getdate())) ");
                sb.Append(") ");
                sb.Append("SELECT @intErrorCode=@@ERROR; ");

                var commandText = sb.ToString();
                sb.Clear();

                using (var dbConnection = _dbProviderFactory.CreateConnection())
                {
                    if (dbConnection == null)
                        throw new ArgumentNullException("dbConnection", "The db connection can't be null.");

                    dbConnection.ConnectionString = _connectionString;

                    using (var dbCommand = _dbProviderFactory.CreateCommand())
                    {
                        if (dbCommand == null)
                            throw new ArgumentNullException("dbCommand" + " The db Insert command for entity [Login] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Parameters
                        _dataHandler.AddParameterToCommand(dbCommand, "@Id", CsType.String, ParameterDirection.Input, entity.UserName);
                        _dataHandler.AddParameterToCommand(dbCommand, "@password", CsType.String, ParameterDirection.Input, entity.Password);
                        //_dataHandler.AddParameterToCommand(dbCommand, "@dtmLastLoginDate", CsType.DateTime, ParameterDirection.Input, entity.LastLoginDate);

                        //Output Parameters
                        _dataHandler.AddParameterToCommand(dbCommand, "@intErrorCode", CsType.Int, ParameterDirection.Output, null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query.
                        _rowsAffected = dbCommand.ExecuteNonQuery();
                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                        {
                            // Throw error.
                            throw new Exception("The Fetch method for entity [Login] reported the Database ErrorCode: " + _errorCode);
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);

                //Bubble error to caller and encapsulate Exception object
                throw new Exception("LoginRepository::Insert::Error occured.", ex);
            }
        }

        public bool Update(LoginEntity entity)
        {
            _errorCode = 0;
            _rowsAffected = 0;

            try
            {
                var sb = new StringBuilder();
                sb.Append("SET DATEFORMAT DMY; ");
                sb.Append("UPDATE [HR].[Login] ");
                sb.Append("SET ");
                sb.Append("[Name] = @chnName, ");
                sb.Append("[Age] = @intAge, ");
                sb.Append("[HiringDate] = @dtmHiringDate, ");
                sb.Append("[GrossSalary] = @decGrossSalary, ");
                sb.Append("[ModifiedDate] = ISNULL(@dtmModifiedDate, (getdate())) ");
                sb.Append("WHERE ");
                sb.Append("[Id] = @intId ");
                sb.Append("SELECT @intErrorCode=@@ERROR; ");

                var commandText = sb.ToString();
                sb.Clear();

                using (var dbConnection = _dbProviderFactory.CreateConnection())
                {
                    if (dbConnection == null)
                        throw new ArgumentNullException("dbConnection", "The db connection can't be null.");

                    dbConnection.ConnectionString = _connectionString;

                    using (var dbCommand = _dbProviderFactory.CreateCommand())
                    {
                        if (dbCommand == null)
                            throw new ArgumentNullException("dbCommand" + " The db Update command for entity [Login] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Parameters
                        _dataHandler.AddParameterToCommand(dbCommand, "@intId", CsType.Int, ParameterDirection.Input, entity.UserName);
                        //_dataHandler.AddParameterToCommand(dbCommand, "@chnName", CsType.String, ParameterDirection.Input, entity.Name);
                        //_dataHandler.AddParameterToCommand(dbCommand, "@intAge", CsType.Int, ParameterDirection.Input, entity.Age);
                        //_dataHandler.AddParameterToCommand(dbCommand, "@dtmHiringDate", CsType.DateTime, ParameterDirection.Input, entity.HiringDate);
                        //_dataHandler.AddParameterToCommand(dbCommand, "@decGrossSalary", CsType.Decimal, ParameterDirection.Input, entity.GrossSalary);
                        _dataHandler.AddParameterToCommand(dbCommand, "@dtmModifiedDate", CsType.DateTime, ParameterDirection.Input, null);

                        //Output Parameters
                        _dataHandler.AddParameterToCommand(dbCommand, "@intErrorCode", CsType.Int, ParameterDirection.Output, null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query.
                        _rowsAffected = dbCommand.ExecuteNonQuery();
                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                        {
                            // Throw error.
                            throw new Exception("The Update method for entity [Login] reported the Database ErrorCode: " + _errorCode);
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);

                //Bubble error to caller and encapsulate Exception object
                throw new Exception("LoginRepository::Update::Error occured.", ex);
            }
        }

        public bool DeleteById(int id)
        {
            _errorCode = 0;
            _rowsAffected = 0;

            try
            {
                var sb = new StringBuilder();
                sb.Append("DELETE FROM [HR].[Login] ");
                sb.Append("WHERE ");
                sb.Append("[Id] = @intId ");
                sb.Append("SELECT @intErrorCode=@@ERROR; ");

                var commandText = sb.ToString();
                sb.Clear();

                using (var dbConnection = _dbProviderFactory.CreateConnection())
                {
                    if (dbConnection == null)
                        throw new ArgumentNullException("dbConnection", "The db connection can't be null.");

                    dbConnection.ConnectionString = _connectionString;

                    using (var dbCommand = _dbProviderFactory.CreateCommand())
                    {
                        if (dbCommand == null)
                            throw new ArgumentNullException("dbCommand" + " The db Delete command for entity [Login] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Parameters
                        _dataHandler.AddParameterToCommand(dbCommand, "@intId", CsType.Int, ParameterDirection.Input, id);

                        //Output Parameters
                        _dataHandler.AddParameterToCommand(dbCommand, "@intErrorCode", CsType.Int, ParameterDirection.Output, null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query.
                        _rowsAffected = dbCommand.ExecuteNonQuery();
                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                        {
                            // Throw error.
                            throw new Exception("The Delete method for entity [Login] reported the Database ErrorCode: " + _errorCode);
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);

                //Bubble error to caller and encapsulate Exception object
                throw new Exception("LoginRepository::Delete::Error occured.", ex);
            }
        }

        public LoginEntity SelectById(int id)
        {
            _errorCode = 0;
            _rowsAffected = 0;

            LoginEntity returnedEntity = null;

            try
            {
                var sb = new StringBuilder();
                sb.Append("SET DATEFORMAT DMY; ");
                sb.Append("SELECT ");
                sb.Append("[Id], ");
                sb.Append("[Name], ");
                sb.Append("[Age], ");
                sb.Append("[HiringDate], ");
                sb.Append("[GrossSalary], ");
                sb.Append("[ModifiedDate] ");
                sb.Append("FROM [HR].[Login] ");
                sb.Append("WHERE ");
                sb.Append("[Id] = @intId ");
                sb.Append("SELECT @intErrorCode=@@ERROR; ");

                var commandText = sb.ToString();
                sb.Clear();

                using (var dbConnection = _dbProviderFactory.CreateConnection())
                {
                    if (dbConnection == null)
                        throw new ArgumentNullException("dbConnection", "The db connection can't be null.");

                    dbConnection.ConnectionString = _connectionString;

                    using (var dbCommand = _dbProviderFactory.CreateCommand())
                    {
                        if (dbCommand == null)
                            throw new ArgumentNullException("dbCommand" + " The db SelectById command for entity [Login] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Parameters
                        _dataHandler.AddParameterToCommand(dbCommand, "@intId", CsType.Int, ParameterDirection.Input, id);

                        //Output Parameters
                        _dataHandler.AddParameterToCommand(dbCommand, "@intErrorCode", CsType.Int, ParameterDirection.Output, null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query.
                        using (var reader = dbCommand.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var entity = new LoginEntity();
                                    entity.UserName = reader.GetString(0);
                                    //entity.UserName = reader.GetInt32(0);
                                    //entity.Name = reader.GetString(1);
                                    //entity.Age = reader.GetInt32(2);
                                    //entity.HiringDate = reader.GetValue(3) == DBNull.Value ? (DateTime?)null : reader.GetDateTime(3);
                                    //entity.GrossSalary = reader.GetDecimal(4);
                                    //entity.ModifiedDate = reader.GetDateTime(5);
                                    returnedEntity = entity;
                                    break;
                                }
                            }
                        }

                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                        {
                            // Throw error.
                            throw new Exception("The SelectById method for entity [Login] reported the Database ErrorCode: " + _errorCode);
                        }
                    }
                }

                return returnedEntity;
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);

                //Bubble error to caller and encapsulate Exception object
                throw new Exception("LoginRepository::SelectById::Error occured.", ex);
            }
        }
        public List<LoginEntity> SelectAll()
        {
            _errorCode = 0;
            _rowsAffected = 0;

            var returnedEntities = new List<LoginEntity>();

            try
            {
                var sb = new StringBuilder();
                sb.Append("SET DATEFORMAT DMY; ");
                sb.Append("SELECT ");
                sb.Append("[Id], ");
                sb.Append("[Name], ");
                sb.Append("[Age], ");
                sb.Append("[HiringDate], ");
                sb.Append("[GrossSalary], ");
                sb.Append("[ModifiedDate] ");
                sb.Append("FROM [HR].[Login] ");
                sb.Append("ORDER BY [Name] ");
                sb.Append("SELECT @intErrorCode=@@ERROR; ");

                var commandText = sb.ToString();
                sb.Clear();

                using (var dbConnection = _dbProviderFactory.CreateConnection())
                {
                    if (dbConnection == null)
                        throw new ArgumentNullException("dbConnection", "The db connection can't be null.");

                    dbConnection.ConnectionString = _connectionString;

                    using (var dbCommand = _dbProviderFactory.CreateCommand())
                    {
                        if (dbCommand == null)
                            throw new ArgumentNullException("dbCommand" + " The db command for entity [Login] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Parameters - None

                        //Output Parameters
                        _dataHandler.AddParameterToCommand(dbCommand, "@intErrorCode", CsType.Int, ParameterDirection.Output, null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query.
                        using (var reader = dbCommand.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var entity = new LoginEntity();
                                    entity.UserName = reader.GetString(0);
                                    //entity.Name = reader.GetString(1);
                                    //entity.Age = reader.GetInt32(2);
                                    //entity.HiringDate = reader.GetValue(3) == DBNull.Value ? (DateTime?)null : reader.GetDateTime(3);
                                    //entity.GrossSalary = reader.GetDecimal(4);
                                    //entity.ModifiedDate = reader.GetDateTime(5);
                                    returnedEntities.Add(entity);
                                }
                            }

                        }

                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                        {
                            // Throw error.
                            throw new Exception("The SelectAll method for entity [Login] reported the Database ErrorCode: " + _errorCode);
                        }
                    }
                }

                return returnedEntities;
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);

                //Bubble error to caller and encapsulate Exception object
                throw new Exception("LoginRepository::SelectAll::Error occured.", ex);
            }
        }

        public LoginRepository()
        {
            //Repository Initializations
            _configurationHandler = new ConfigurationHandler();
            _loggingHandler = new LoggingHandler();
            _dataHandler = new DataHandler();
            _connectionString = _configurationHandler.ConnectionString;
            _connectionProvider = _configurationHandler.ConnectionProvider;
            _dbProviderFactory = DbProviderFactories.GetFactory(_connectionProvider);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool bDisposing)
        {
            // Check to see if Dispose has already been called.
            if (!_bDisposed)
            {
                if (bDisposing)
                {
                    // Dispose managed resources.
                    _configurationHandler = null;
                    _loggingHandler = null;
                    _dataHandler = null;
                    _dbProviderFactory = null;
                }
            }
            _bDisposed = true;
        }


        public LoginEntity SelectByUserName(string UserName)
        {
            _errorCode = 0;
            _rowsAffected = 0;

            LoginEntity returnedEntity = null;

            try
            {
                var sb = new StringBuilder();
                sb.Append("SET DATEFORMAT DMY; ");
                sb.Append("SELECT ");
                sb.Append("[Id], ");
                sb.Append("[Name], ");
                sb.Append("[Age], ");
                sb.Append("[HiringDate], ");
                sb.Append("[GrossSalary], ");
                sb.Append("[ModifiedDate] ");
                sb.Append("FROM [HR].[Login] ");
                sb.Append("WHERE ");
                sb.Append("[Id] = @intId ");
                sb.Append("SELECT @intErrorCode=@@ERROR; ");

                var commandText = sb.ToString();
                sb.Clear();

                using (var dbConnection = _dbProviderFactory.CreateConnection())
                {
                    if (dbConnection == null)
                        throw new ArgumentNullException("dbConnection", "The db connection can't be null.");

                    dbConnection.ConnectionString = _connectionString;

                    using (var dbCommand = _dbProviderFactory.CreateCommand())
                    {
                        if (dbCommand == null)
                            throw new ArgumentNullException("dbCommand" + " The db SelectByUserName command for entity [Login] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Parameters
                        //_dataHandler.AddParameterToCommand(dbCommand, "@intId", CsType.Int, ParameterDirection.Input, id);

                        //Output Parameters
                        _dataHandler.AddParameterToCommand(dbCommand, "@intErrorCode", CsType.Int, ParameterDirection.Output, null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query.
                        using (var reader = dbCommand.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var entity = new LoginEntity();
                                    entity.UserName = reader.GetString(0);
                                    //entity.Name = reader.GetString(1);
                                    //entity.Age = reader.GetInt32(2);
                                    //entity.HiringDate = reader.GetValue(3) == DBNull.Value ? (DateTime?)null : reader.GetDateTime(3);
                                    //entity.GrossSalary = reader.GetDecimal(4);
                                    //entity.ModifiedDate = reader.GetDateTime(5);
                                    returnedEntity = entity;
                                    break;
                                }
                            }
                        }

                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                        {
                            // Throw error.
                            throw new Exception("The SelectById method for entity [Login] reported the Database ErrorCode: " + _errorCode);
                        }
                    }
                }

                return returnedEntity;
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);

                //Bubble error to caller and encapsulate Exception object
                throw new Exception("LoginRepository::SelectById::Error occured.", ex);
            }
        }
        #endregion
    }
}
