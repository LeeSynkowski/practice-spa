using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CodeCamper.Data.Configurations;
using CodeCamper.Data.SampleData;
using CodeCamper.Model;

namespace CodeCamper.Data
{
    public class CodeCamperDbContext : DbContext
    {
        public CodeCamperDbContext() 
            : base(nameOrConnectionString:"CodeCamper"){}

        public DbSet<Session> Sessions { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
 
        // Lookup Lists
        public DbSet<Room> Rooms { get; set; } 
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<Track> Tracks { get; set; } 

        //create seed data
        static CodeCamperDbContext()
        {
            //for development only
            Database.SetInitializer((new CodeCamperDatabaseInitializer()));
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //this removes the normal behavior of adding plural tables
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();

            //adding configurations for sessions and attendance
            modelBuilder.Configurations.Add(new SessionConfiguration());
            modelBuilder.Configurations.Add(new AttendanceConfiguration());
        }
    }
}
