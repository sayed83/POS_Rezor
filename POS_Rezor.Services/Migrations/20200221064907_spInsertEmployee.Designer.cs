﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using POS_Rezor.Services;

namespace POS_Rezor.Services.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200221064907_spInsertEmployee")]
    partial class spInsertEmployee
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("POS_Rezor.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Department")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("POS_Rezor.Models.ImageCriteria", b =>
                {
                    b.Property<int>("ImageCriteriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageCriteriaCaption")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ImageCriteriaId");

                    b.ToTable("ImageCriterias");
                });

            modelBuilder.Entity("POS_Rezor.Models.MenuPermission_Details", b =>
                {
                    b.Property<int>("MenuPermissionDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCreated")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsReport")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUpdated")
                        .HasColumnType("bit");

                    b.Property<bool>("IsView")
                        .HasColumnType("bit");

                    b.Property<int>("MenuPermissionMasterId")
                        .HasColumnType("int");

                    b.Property<int?>("MenuPermission_MasterMenuPermissionMasterId")
                        .HasColumnType("int");

                    b.Property<int>("ModuleMenuId")
                        .HasColumnType("int");

                    b.HasKey("MenuPermissionDetailsId");

                    b.HasIndex("MenuPermission_MasterMenuPermissionMasterId");

                    b.HasIndex("ModuleMenuId");

                    b.ToTable("MenuPermission_Details");
                });

            modelBuilder.Entity("POS_Rezor.Models.MenuPermission_Master", b =>
                {
                    b.Property<int>("MenuPermissionMasterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("AddedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("comid")
                        .HasColumnType("int");

                    b.Property<string>("userid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("useridPermission")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("useridUpdate")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MenuPermissionMasterId");

                    b.ToTable("MenuPermission_Masters");
                });

            modelBuilder.Entity("POS_Rezor.Models.ModuleGroup", b =>
                {
                    b.Property<int>("ModuleGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageExtension")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModuleGroupCaption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ModuleGroupImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ModuleGroupName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModuleId")
                        .HasColumnType("int");

                    b.Property<int?>("ModulesModuleId")
                        .HasColumnType("int");

                    b.Property<int?>("SLNO")
                        .HasColumnType("int");

                    b.HasKey("ModuleGroupId");

                    b.HasIndex("ModulesModuleId");

                    b.ToTable("ModuleGroups");
                });

            modelBuilder.Entity("POS_Rezor.Models.ModuleMenu", b =>
                {
                    b.Property<int>("ModuleMenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("ImageCriteriaId")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IsInActive")
                        .HasColumnType("int");

                    b.Property<string>("IsParent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModuleGroupId")
                        .HasColumnType("int");

                    b.Property<int>("ModuleId")
                        .HasColumnType("int");

                    b.Property<string>("ModuleImageExtension")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModuleMenuCaption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModuleMenuController")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ModuleMenuImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ModuleMenuLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModuleMenuName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ModulesModuleId")
                        .HasColumnType("int");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<int?>("ParentModuleMenuModuleMenuId")
                        .HasColumnType("int");

                    b.Property<int?>("SLNO")
                        .HasColumnType("int");

                    b.HasKey("ModuleMenuId");

                    b.HasIndex("ImageCriteriaId");

                    b.HasIndex("ModuleGroupId");

                    b.HasIndex("ModulesModuleId");

                    b.HasIndex("ParentModuleMenuModuleMenuId");

                    b.ToTable("ModuleMenues");
                });

            modelBuilder.Entity("POS_Rezor.Models.Modules", b =>
                {
                    b.Property<int>("ModuleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IsInActive")
                        .HasColumnType("int");

                    b.Property<string>("ModuleCaption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModuleCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModuleDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ModuleImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ModuleImageExtension")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModuleImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModuleLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModuleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SLNO")
                        .HasColumnType("int");

                    b.HasKey("ModuleId");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("POS_Rezor.Models.MenuPermission_Details", b =>
                {
                    b.HasOne("POS_Rezor.Models.MenuPermission_Master", "MenuPermission_Master")
                        .WithMany("MenuPermission_Details")
                        .HasForeignKey("MenuPermission_MasterMenuPermissionMasterId");

                    b.HasOne("POS_Rezor.Models.ModuleMenu", "ModuleMenu")
                        .WithMany()
                        .HasForeignKey("ModuleMenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("POS_Rezor.Models.ModuleGroup", b =>
                {
                    b.HasOne("POS_Rezor.Models.Modules", "Modules")
                        .WithMany("ModuleGroups")
                        .HasForeignKey("ModulesModuleId");
                });

            modelBuilder.Entity("POS_Rezor.Models.ModuleMenu", b =>
                {
                    b.HasOne("POS_Rezor.Models.ImageCriteria", "ImageCriteria")
                        .WithMany()
                        .HasForeignKey("ImageCriteriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POS_Rezor.Models.ModuleGroup", "ModuleGroup")
                        .WithMany("ModuleMenu")
                        .HasForeignKey("ModuleGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POS_Rezor.Models.Modules", "Modules")
                        .WithMany()
                        .HasForeignKey("ModulesModuleId");

                    b.HasOne("POS_Rezor.Models.ModuleMenu", "ParentModuleMenu")
                        .WithMany("ModuleMenuChildren")
                        .HasForeignKey("ParentModuleMenuModuleMenuId");
                });
#pragma warning restore 612, 618
        }
    }
}
