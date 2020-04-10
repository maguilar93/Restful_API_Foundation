using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TodoApi.Models;


namespace TodoApi.Models
{
    public class MysqlContext : DbContext
    {
        public MysqlContext(DbContextOptions<MysqlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<addresses> addresses { get; set; }
        public virtual DbSet<building_details> building_details { get; set; }
        public DbSet<buildings> buildings { get; set; }
        public DbSet<columns> columns { get; set; }
        public DbSet<customers> customers { get; set; }
        public virtual DbSet<elevators> elevators { get; set; }
        public DbSet<employees> employees { get; set; }
        public  DbSet<leads> leads { get; set; }
        public virtual DbSet<batteries> batteries { get; set; }
        public virtual DbSet<quotes> quotes { get; set; }
        public virtual DbSet<users> users { get; set; }
        public virtual DbSet<interventions> interventions { get; set; }
        protected override void OnModelCreating (ModelBuilder modelBuilder) {

         modelBuilder.Entity<batteries> (entity => {
                entity.ToTable ("batteries");

                entity.HasIndex (e => e.building_id)
                    .HasName ("index_batteries_on_building_id");

                // entity.HasIndex (e => e.employee_id)
                //    .HasName ("index_batteries_on_employee_id");

                entity.Property (e => e.id)
                    .HasColumnName ("id")
                    .HasColumnType ("bigint(20)");

                entity.Property (e => e.building_id)
                    .HasColumnName ("building_id")
                    .HasColumnType ("bigint(20)");

                // entity.Property (e => e.building_type)
                //     .HasColumnName ("building_type")
                //     .HasColumnType ("varchar(255)");

                entity.Property (e => e.created_at)
                    .HasColumnName ("created_at")
                    .HasColumnType ("datetime");

                // entity.Property (e => e.employee_id)
                //     .HasColumnName ("employee_id")
                //     .HasColumnType ("bigint(20)");

                // entity.Property (e => e.InServiceSince)
                //     .HasColumnName ("in_service_since")
                //     .HasColumnType ("date");

                // entity.Property (e => e.Information)
                //     .HasColumnName ("information")
                //     .HasColumnType ("text");

                // entity.Property (e => e.LastInspection)
                //     .HasColumnName ("last_inspection")
                //     .HasColumnType ("date");

                // entity.Property (e => e.Notes)
                //     .HasColumnName ("notes")
                //     .HasColumnType ("text");
                // entity.Property (e => e.OperationsCertificate)
                //     .HasColumnName ("operations_certificate")
                //     .HasColumnType ("varchar(255)");

                entity.Property (e => e.status)
                    .HasColumnName ("status")
                    .HasColumnType ("varchar(255)");

                entity.Property (e => e.updated_at)
                    .HasColumnName ("updated_at")
                    .HasColumnType ("datetime");

                entity.HasOne (d => d.building)
                    .WithMany (p => p.batteries)
                    .HasForeignKey (d => d.building_id)
                    .HasConstraintName ("fk_rails_fc40470545");

                // entity.HasOne (d => d.employee)SSS
                //     .WithMany (p => p.batteries)
                //     .HasForeignKey (d => d.employee_id)
                //     .HasConstraintName ("fk_rails_ceeeaf55f7");
            });

             modelBuilder.Entity<building_details> (entity => {
                entity.ToTable ("building_details");

                entity.HasIndex (e => e.building_id)
                    .HasName ("index_building_details_on_building_id");

                entity.Property (e => e.id)
                    .HasColumnName ("id")
                    .HasColumnType ("bigint(20)");

                entity.Property (e => e.building_id)
                    .HasColumnName ("building_id")
                    .HasColumnType ("bigint(20)");

                // entity.Property (e => e.created_at)
                //     .HasColumnName ("created_at")
                //     .HasColumnType ("datetime");

                // entity.Property (e => e.info_key)
                //     .HasColumnName ("info_key")
                //     .HasColumnType ("varchar(255)");

                // entity.Property (e => e.updated_at)
                //     .HasColumnName ("updated_at")
                //     .HasColumnType ("datetime");

                // entity.Property (e => e.value)
                //     .HasColumnName ("value")
                //     .HasColumnType ("varchar(255)");

                entity.HasOne (d => d.building)
                    .WithMany (p => p.building_details)
                    .HasForeignKey (d => d.building_id)
                    .HasConstraintName ("fk_rails_51749f8eac");
            });

            modelBuilder.Entity<interventions> ()
                .ToTable("interventions")
                .HasKey(x => x.id);

            modelBuilder.Entity<buildings> (entity => {
                entity.ToTable ("buildings");

                // entity.HasIndex (e => e.address_id)
                //     .HasName ("index_building_on_address_id");

                // entity.HasIndex (e => e.customer_id)
                //     .HasName ("index_building_on_customer_id");

                entity.Property (e => e.id)
                    .HasColumnName ("id")
                    .HasColumnType ("bigint(20)");

                // entity.Property (e => e.address_id)
                //     .HasColumnName ("address_id")
                //     .HasColumnType ("bigint(20)");

                // entity.Property (e => e.administrator_email)
                //     .HasColumnName ("administrator_email")
                //     .HasColumnType ("varchar(255)");

                // entity.Property (e => e.admin_full_name)
                //     .HasColumnName ("administrator_full_name")
                //     .HasColumnType ("varchar(255)");

                // entity.Property (e => e.AdministratorPhone)
                //     .HasColumnName ("administrator_phone")
                //     .HasColumnType ("varchar(255)");

                // entity.Property (e => e.BuildingName)
                //     .HasColumnName ("building_name")
                //     .HasColumnType ("varchar(255)");

                // entity.Property (e => e.created_at)
                //     .HasColumnName ("created_at")
                //     .HasColumnType ("datetime");

                // entity.Property (e => e.customer_id)
                //     .HasColumnName ("customer_id")
                //     .HasColumnType ("bigint(20)");

                // entity.Property (e => e.TechnicianEmail)
                //     .HasColumnName ("technician_email")
                //     .HasColumnType ("varchar(255)");

                // entity.Property (e => e.TechnicianFullName)
                //     .HasColumnName ("technician_full_name")
                //     .HasColumnType ("varchar(255)");

                // entity.Property (e => e.TechnicianPhone)
                //     .HasColumnName ("technician_phone")
                //     .HasColumnType ("varchar(255)");

                // entity.Property (e => e.UpdatedAt)
                //     .HasColumnName ("updated_at")
                //     .HasColumnType ("datetime");

                // entity.HasOne (d => d.Address)
                //     .WithMany (p => p.building)
                //     .HasForeignKey (d => d.address_id)
                //     .HasConstraintName ("fk_rails_6dc7a885ab");

                // entity.HasOne (d => d.Customer)
                //     .WithMany (p => p.buildings)
                //     .HasForeignKey (d => d.customer_id)
                //     .HasConstraintName ("fk_rails_c29cbe7fb8");
            });

            modelBuilder.Entity<columns> (entity => {
                entity.ToTable ("columns");

                entity.HasIndex (e => e.battery_id)
                    .HasName ("index_columns_on_battery_id");

                entity.Property (e => e.id)
                    .HasColumnName ("id")
                    .HasColumnType ("bigint(20)");

                entity.Property (e => e.battery_id)
                    .HasColumnName ("battery_id")
                    .HasColumnType ("bigint(20)");

                // entity.Property (e => e.building_type)
                //     .HasColumnName ("building_type")
                //     .HasColumnType ("varchar(255)");

                // entity.Property (e => e.created_at)
                //     .HasColumnName ("created_at")
                //     .HasColumnType ("datetime");

                // entity.Property (e => e.FloorsServed)
                //     .HasColumnName ("floors_served")
                //     .HasColumnType ("int(11)");

                // entity.Property (e => e.Information)
                //     .HasColumnName ("information")
                //     .HasColumnType ("text");

                // entity.Property (e => e.Notes)
                //     .HasColumnName ("notes")
                //     .HasColumnType ("text");

                entity.Property (e => e.status)
                    .HasColumnName ("status")
                    .HasColumnType ("varchar(255)");

                // entity.Property (e => e.UpdatedAt)
                //     .HasColumnName ("updated_at")
                //     .HasColumnType ("datetime");

                entity.HasOne (d => d.battery)
                    .WithMany (p => p.columns)
                    .HasForeignKey (d => d.battery_id)
                    .HasConstraintName ("fk_rails_021eb14ac4");
            });



            modelBuilder.Entity<elevators> (entity => {
                entity.ToTable ("elevators");

                entity.HasIndex (e => e.column_id)
                    .HasName ("index_elevators_on_column_id");

                entity.Property (e => e.Id)
                    .HasColumnName ("id")
                    .HasColumnType ("bigint(20)");

                // entity.Property (e => e.building_type)
                //     .HasColumnName ("building_type")
                //     .HasColumnType ("varchar(255)");

                entity.Property (e => e.column_id)
                    .HasColumnName ("column_id")
                    .HasColumnType ("bigint(20)");

                // entity.Property (e => e.CreatedAt)
                //     .HasColumnName ("created_at")
                //     .HasColumnType ("datetime");

                // entity.Property (e => e.InServiceSince)
                //     .HasColumnName ("in_service_since")
                //     .HasColumnType ("date");

                // entity.Property (e => e.Information)
                //     .HasColumnName ("information")
                //     .HasColumnType ("text");

                // entity.Property (e => e.InspectionCertificate)
                //     .HasColumnName ("inspection_certificate")
                //     .HasColumnType ("varchar(255)");

                // entity.Property (e => e.LastInspection)
                //     .HasColumnName ("last_inspection")
                //     .HasColumnType ("date");

                // entity.Property (e => e.Model)
                //     .HasColumnName ("model")
                //     .HasColumnType ("varchar(255)");

                // entity.Property (e => e.Notes)
                //     .HasColumnName ("notes")
                //     .HasColumnType ("text");

                // entity.Property (e => e.SerialNumber)
                //     .HasColumnName ("serial_number")
                //     .HasColumnType ("int(11)");

                entity.Property (e => e.status)
                    .HasColumnName ("status")
                    .HasColumnType ("varchar(255)");

                // entity.Property (e => e.UpdatedAt)
                //     .HasColumnName ("updated_at")
                //     .HasColumnType ("datetime");

                entity.HasOne (d => d.column)
                    .WithMany (p => p.elevators)
                    .HasForeignKey (d => d.column_id)
                    .HasConstraintName ("fk_rails_69442d7bc2");
            });


            modelBuilder.Entity<customers> (entity => {
                entity.ToTable ("customers");
 
                    entity.Property (e => e.id)
                    .HasColumnName ("id")
                    .HasColumnType ("bigint(20)");

                 

                   

                    entity.Property (e => e.company_desc)
                    .HasColumnName ("company_desc")
                    .HasColumnType ("varchar(255)");

                // entity.Property (e => e.BusinessName)
                //     .HasColumnName ("business_name")
                //     .HasColumnType ("varchar(255)");

                entity.Property (e => e.contact_email)
                    .HasColumnName ("contact_email")
                    .HasColumnType ("varchar(255)");

                // entity.Property (e => e.ContactFullName)
                //     .HasColumnName ("contact_full_name")
                //     .HasColumnType ("varchar(255)");

                // entity.Property (e => e.ContactPhone)
                //     .HasColumnName ("contact_phone")
                //     .HasColumnType ("varchar(255)");

                // entity.Property (e => e.CreatedAt)
                //     .HasColumnName ("created_at")
                //     .HasColumnType ("datetime");



                entity.Property (e => e.tech_manager_email)
                    .HasColumnName ("tech_manager_email")
                    .HasColumnType ("varchar(255)");

                entity.Property (e => e.full_name_STA)
                    .HasColumnName ("full_name_STA")
                    .HasColumnType ("varchar(255)");

                entity.Property (e => e.tech_authority_phone )
                    .HasColumnName ("tech_authority_phone")
                    .HasColumnType ("varchar(255)");

                entity.Property (e => e.updated_at)
                    .HasColumnName ("updated_at")
                    .HasColumnType ("datetime");

                 });


            modelBuilder.Entity<leads> (entity => {
                entity.ToTable ("leads");

                 entity.Property (e => e.Id)
                    .HasColumnName ("id")
                    .HasColumnType ("bigint(20)");

                   

                entity.Property (e => e.Company_name)
                    .HasColumnName ("company_name")
                    .HasColumnType ("varchar(255)");

                entity.Property (e => e.Created_at)
                    .HasColumnName ("created_at")
                    .HasColumnType ("datetime");

                entity.Property (e => e.Department)
                    .HasColumnName ("department")
                    .HasColumnType ("varchar(255)");

                entity.Property (e => e.Email)
                    .HasColumnName ("email")
                    .HasColumnType ("varchar(255)");

             

                entity.Property (e => e.Full_name)
                    .HasColumnName ("full_name")
                    .HasColumnType ("varchar(255)");

                entity.Property (e => e.Message)
                    .HasColumnName ("message")
                    .HasColumnType ("text");

                // entity.Property (e => e.OriginalFileName)
                //     .HasColumnName ("original_file_name")
                //     .HasColumnType ("varchar(255)");

                entity.Property (e => e.Phone)
                    .HasColumnName ("phone")
                    .HasColumnType ("varchar(255)");

                // entity.Property (e => e.project_desc)
                //     .HasColumnName ("project_description")
                //     .HasColumnType ("text");

                entity.Property (e => e.project_name)
                    .HasColumnName ("project_name")
                    .HasColumnType ("varchar(255)");

                entity.Property (e => e.Updated_at)
                    .HasColumnName ("updated_at")
                    .HasColumnType ("datetime");


 
                    

                 });
    }


    }
}