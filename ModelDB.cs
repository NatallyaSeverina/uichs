namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.SqlClient;
    using System.Collections.Generic;

    public partial class ModelDB : DbContext
    {
        public ModelDB()
            : base("name=ModelDB")
        {
        }
        public void AddVechicle2Emergency(int _emergencyID, string _nameVechicle, int _countVechicle)
        {
           // object[] parameters = new object[] { _emergencyID, _nameVechicle, _countVechicle };
            List<SqlParameter> parameterList = new List<SqlParameter>();
            parameterList.Add(new SqlParameter("@emergencyID", _emergencyID));
            parameterList.Add(new SqlParameter("@nameVechicle", _nameVechicle));
            parameterList.Add(new SqlParameter("@addCountVechicle", _countVechicle));
            SqlParameter[] parameters = parameterList.ToArray();
            var sql = @"exec AddVechicle2Emergency @emergencyID,@nameVechicle,@addCountVechicle";
             Database.ExecuteSqlCommand(sql,parameters);
        }
        public virtual DbSet<DutyOfficer> DutyOfficers { get; set; }
        public virtual DbSet<EmergencySituation> EmergencySituations { get; set; }
        public virtual DbSet<ReceivedMessage> ReceivedMessages { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<SuperiorOfficer> SuperiorOfficers { get; set; }
        public virtual DbSet<Vechicle2Emergency> Vechicle2Emergency { get; set; }
        public virtual DbSet<Vechicle> Vechicles { get; set; }
        public virtual DbSet<Victim> Victims { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DutyOfficer>()
                .Property(e => e.nameDutyOfficer)
                .IsUnicode(false);

            modelBuilder.Entity<DutyOfficer>()
                .Property(e => e.positionDuty)
                .IsUnicode(false);

            modelBuilder.Entity<DutyOfficer>()
                .Property(e => e.loginDutyOfficer)
                .IsUnicode(false);

            modelBuilder.Entity<DutyOfficer>()
                .Property(e => e.passwordDutyOfficer)
                .IsUnicode(false);

            modelBuilder.Entity<DutyOfficer>()
                .HasMany(e => e.ReceivedMessages)
                .WithRequired(e => e.DutyOfficer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EmergencySituation>()
                .Property(e => e.region)
                .IsUnicode(false);

            modelBuilder.Entity<EmergencySituation>()
                .Property(e => e.neighborhood)
                .IsUnicode(false);

            modelBuilder.Entity<EmergencySituation>()
                .Property(e => e.popylatedLocality)
                .IsUnicode(false);

            modelBuilder.Entity<EmergencySituation>()
                .Property(e => e.adress)
                .IsUnicode(false);

            modelBuilder.Entity<EmergencySituation>()
                .Property(e => e.kind)
                .IsUnicode(false);

            modelBuilder.Entity<EmergencySituation>()
                .Property(e => e.descriptionOfEmergency)
                .IsUnicode(false);

            modelBuilder.Entity<EmergencySituation>()
                .Property(e => e.problematicIssues)
                .IsUnicode(false);

            modelBuilder.Entity<EmergencySituation>()
                .Property(e => e.extraReportSuperiorOfficer)
                .IsUnicode(false);

            modelBuilder.Entity<EmergencySituation>()
                .Property(e => e.editLog)
                .IsUnicode(false);

            modelBuilder.Entity<EmergencySituation>()
                .HasOptional(e => e.ReceivedMessage)
                .WithRequired(e => e.EmergencySituation);

            modelBuilder.Entity<EmergencySituation>()
                .HasMany(e => e.SuperiorOfficers)
                .WithRequired(e => e.EmergencySituation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EmergencySituation>()
                .HasMany(e => e.Vechicle2Emergency)
                .WithRequired(e => e.EmergencySituation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EmergencySituation>()
                .HasOptional(e => e.Victim)
                .WithRequired(e => e.EmergencySituation);

            modelBuilder.Entity<SuperiorOfficer>()
                .Property(e => e.position)
                .IsUnicode(false);

            modelBuilder.Entity<Vechicle>()
                .Property(e => e.nameVechicle)
                .IsUnicode(false);

            modelBuilder.Entity<Vechicle>()
                .HasMany(e => e.Vechicle2Emergency)
                .WithRequired(e => e.Vechicle)
                .WillCascadeOnDelete(false);
        }
    }
}
