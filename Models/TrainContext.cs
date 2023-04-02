using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace TrainWork.Models;

public partial class TrainContext : DbContext
{
    public TrainContext()
    {
    }

    public TrainContext(DbContextOptions<TrainContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bilet> Bilets { get; set; }

    public virtual DbSet<Marshrut> Marshruts { get; set; }

    public virtual DbSet<OllOtrezok> OllOtrezoks { get; set; }

    public virtual DbSet<Otrezok> Otrezoks { get; set; }

    public virtual DbSet<Passenger> Passengers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<TrainWagon> TrainWagons { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Wagon> Wagons { get; set; }

    public virtual DbSet<Zakaz> Zakazs { get; set; }

    public virtual DbSet<ZakazBilet> ZakazBilets { get; set; }

    string putik = PacHt();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite(putik);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bilet>(entity =>
        {
            entity.ToTable("Bilet");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FkPassenger).HasColumnName("fk_passenger");
            entity.Property(e => e.FkTrain).HasColumnName("fk_train");
            entity.Property(e => e.FkWagon).HasColumnName("fk_wagon");
            entity.Property(e => e.Mesto).HasColumnName("mesto");
            entity.Property(e => e.Summ).HasColumnName("summ");

            entity.HasOne(d => d.FkPassengerNavigation).WithMany(p => p.Bilets).HasForeignKey(d => d.FkPassenger);

            entity.HasOne(d => d.FkWagonNavigation).WithMany(p => p.Bilets).HasForeignKey(d => d.FkWagon);
        });

        modelBuilder.Entity<Marshrut>(entity =>
        {
            entity.ToTable("Marshrut");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FkTrain).HasColumnName("fk_train");
            entity.Property(e => e.NameMarshrut).HasColumnName("name_marshrut");
        });

        modelBuilder.Entity<OllOtrezok>(entity =>
        {
            entity.ToTable("OllOtrezok");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FkMarshrut).HasColumnName("fk_marshrut");
            entity.Property(e => e.FkOtrezok).HasColumnName("fk_otrezok");

            entity.HasOne(d => d.FkMarshrutNavigation).WithMany(p => p.OllOtrezoks).HasForeignKey(d => d.FkMarshrut);

            entity.HasOne(d => d.FkOtrezokNavigation).WithMany(p => p.OllOtrezoks).HasForeignKey(d => d.FkOtrezok);
        });

        modelBuilder.Entity<Otrezok>(entity =>
        {
            entity.ToTable("Otrezok");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateO).HasColumnName("date_o");
            entity.Property(e => e.DateP).HasColumnName("date_p");
            entity.Property(e => e.NameA).HasColumnName("name_a");
            entity.Property(e => e.NameB).HasColumnName("name_b");
            entity.Property(e => e.Summ).HasColumnName("summ");
        });

        modelBuilder.Entity<Passenger>(entity =>
        {
            entity.ToTable("Passenger");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.Document).HasColumnName("document");
            entity.Property(e => e.FName).HasColumnName("f_name");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.IName).HasColumnName("i_name");
            entity.Property(e => e.OName).HasColumnName("o_name");
            entity.Property(e => e.Telephone)
                .HasDefaultValueSql("\"88004440011\"")
                .HasColumnName("telephone");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NameRole)
                .HasDefaultValueSql("\"Кассир\"")
                .HasColumnName("name_role");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("Status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NameStatus)
                .HasDefaultValueSql("\"Активный\"")
                .HasColumnName("name_status");
        });

        modelBuilder.Entity<TrainWagon>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TrainWagon");

            entity.Property(e => e.FkWagon).HasColumnName("fk_wagon");
            entity.Property(e => e.IdTrainwagon).HasColumnName("id_trainwagon");

            entity.HasOne(d => d.FkWagonNavigation).WithMany().HasForeignKey(d => d.FkWagon);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FU).HasColumnName("f_u");
            entity.Property(e => e.FkRole).HasColumnName("fk_role");
            entity.Property(e => e.IU).HasColumnName("i_u");
            entity.Property(e => e.Login).HasColumnName("login");
            entity.Property(e => e.OU).HasColumnName("o_u");
            entity.Property(e => e.Password).HasColumnName("password");

            entity.HasOne(d => d.FkRoleNavigation).WithMany(p => p.Users).HasForeignKey(d => d.FkRole);
        });

        modelBuilder.Entity<Wagon>(entity =>
        {
            entity.ToTable("Wagon");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClassWagon).HasColumnName("class_wagon");
            entity.Property(e => e.Mesto).HasColumnName("mesto");
        });

        modelBuilder.Entity<Zakaz>(entity =>
        {
            entity.ToTable("Zakaz");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FkStatus).HasColumnName("fk_status");
            entity.Property(e => e.FkUser).HasColumnName("fk_user");

            entity.HasOne(d => d.FkStatusNavigation).WithMany(p => p.Zakazs).HasForeignKey(d => d.FkStatus);

            entity.HasOne(d => d.FkUserNavigation).WithMany(p => p.Zakazs).HasForeignKey(d => d.FkUser);
        });

        modelBuilder.Entity<ZakazBilet>(entity =>
        {
            entity.ToTable("ZakazBilet");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FkBilet).HasColumnName("fk_bilet");
            entity.Property(e => e.FkZakaz).HasColumnName("fk_zakaz");

            entity.HasOne(d => d.FkBiletNavigation).WithMany(p => p.ZakazBilets).HasForeignKey(d => d.FkBilet);

            entity.HasOne(d => d.FkZakazNavigation).WithMany(p => p.ZakazBilets).HasForeignKey(d => d.FkZakaz);
        });

        OnModelCreatingPartial(modelBuilder);

    }

        //Относительный путь
        static private string PacHt()
        {
            var x = Directory.GetCurrentDirectory();
            var y = Directory.GetParent(x).FullName;
            var c = Directory.GetParent(y).FullName;
            var r = "Data Source=" + Directory.GetParent(c).FullName + @"\DbA\train.db";
            return r;
        }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
