using DaniaDaisy.DataAccess.Common.Model;
using System;
using Microsoft.EntityFrameworkCore;
namespace DaniaDaisy.DataAccess.Common.Logger
{
    public class DatabaseLogger : DataAccessLogger
    {
        private DatabaseSink _Sink { get; set; }
        public DatabaseLogger(ILoggerSink sink)
        {
            _Sink = sink as DatabaseSink;
        }
        public override void Log(DataAccessFootprint logDetails)
        {
            lock (logLocker)
            {
                if (_Sink == null)
                {
                    Console.WriteLine("There is no database sink being setup");
                }
                else
                {
                    try
                    {
                        LoggerDBContext db = new LoggerDBContext(_Sink.DatabaseConnectionString);
                        db.DataAccessLogger.Add(logDetails.ConvertToEntity());
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Data Access Sink Error : Batabase Sink , Error : " + ex.Message);
                    }
                }
            }
        }
    }

    internal partial class DataAccessLoggerEntity
    {
        public Guid DataAccessTransactionId { get; set; }
        public string Operation { get; set; }
        public string MethodName { get; set; }
        public string Message { get; set; }
        public string SourceMachineName { get; set; }
        public string SourceApplicationDomainName { get; set; }
        public string ReferralLibrary { get; set; }
    }

    internal partial class LoggerDBContext : DbContext
    {
        private readonly string ConnectionString;

        public LoggerDBContext(string connectionstring) :base()
        {
            this.ConnectionString = connectionstring;
        }
        public LoggerDBContext(DbContextOptions<LoggerDBContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<DataAccessLoggerEntity> DataAccessLogger { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(this.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataAccessLoggerEntity>(entity =>
            {
            
                entity.HasKey(e => e.DataAccessTransactionId);

                entity.Property(e => e.DataAccessTransactionId).ValueGeneratedNever();

                entity.Property(e => e.MethodName).HasMaxLength(200);

                entity.Property(e => e.Operation)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ReferralLibrary).HasMaxLength(200);

                entity.Property(e => e.SourceApplicationDomainName).HasMaxLength(200);

                entity.Property(e => e.SourceMachineName).HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

    internal static class Converter
    {
        public static DataAccessLoggerEntity ConvertToEntity(this DataAccessFootprint Data)
        {
            return new DataAccessLoggerEntity()
            {
                DataAccessTransactionId = Data.DataAccessTransactionId,
                Message = Data.Message,
                MethodName = Data.MethodName,
                Operation = Data.Operation.ToString(),
                ReferralLibrary = Data.ReferralLibrary,
                SourceApplicationDomainName = Data.SourceApplicationDomainName,
                SourceMachineName = Data.SourceMachineName,
            };
        }
    }
}
