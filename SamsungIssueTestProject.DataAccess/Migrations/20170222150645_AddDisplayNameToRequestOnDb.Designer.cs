using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SamsungIssueTestProject.DataAccess;

namespace SamsungIssueTestProject.DataAccess.Migrations
{
    [DbContext(typeof(FadContext))]
    [Migration("20170222150645_AddDisplayNameToRequestOnDb")]
    partial class AddDisplayNameToRequestOnDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("SamsungIssueTestProject.DataAccess.Models.Contact", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("HasUnsavedChanges");

                    b.Property<long>("IdAddressbook");

                    b.Property<long>("IdService");

                    b.Property<byte[]>("Image");

                    b.Property<bool>("IsAllowedToReceiveMyInfos");

                    b.Property<bool>("IsMe");

                    b.Property<string>("MiddleName");

                    b.Property<string>("Name");

                    b.Property<string>("Prename");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("SamsungIssueTestProject.DataAccess.Models.ContactAddress", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<long>("ContactId");

                    b.Property<string>("Country");

                    b.Property<bool>("HasUnsavedChanges");

                    b.Property<long>("IdAddressbook");

                    b.Property<long>("IdService");

                    b.Property<int>("InfoType");

                    b.Property<string>("Postcode");

                    b.Property<string>("Street");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("ContactAddresss");
                });

            modelBuilder.Entity("SamsungIssueTestProject.DataAccess.Models.ContactEvent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("ContactId");

                    b.Property<bool>("HasUnsavedChanges");

                    b.Property<long>("IdAddressbook");

                    b.Property<long>("IdService");

                    b.Property<int>("InfoType");

                    b.Property<string>("Name");

                    b.Property<int>("Periodicity");

                    b.Property<DateTime>("Start");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("ContactEvents");
                });

            modelBuilder.Entity("SamsungIssueTestProject.DataAccess.Models.ContactInfo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("ContactId");

                    b.Property<bool>("HasUnsavedChanges");

                    b.Property<long>("IdAddressbook");

                    b.Property<long>("IdService");

                    b.Property<string>("Info");

                    b.Property<int>("InfoType");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("ContactInfos");
                });

            modelBuilder.Entity("SamsungIssueTestProject.DataAccess.Models.Request", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Displayname");

                    b.Property<bool>("IsEstablished");

                    b.Property<string>("UserFromNumber");

                    b.Property<string>("UserToNumber");

                    b.HasKey("Id");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("SamsungIssueTestProject.DataAccess.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("IdService");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SamsungIssueTestProject.DataAccess.Models.Contact", b =>
                {
                    b.HasOne("SamsungIssueTestProject.DataAccess.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SamsungIssueTestProject.DataAccess.Models.ContactAddress", b =>
                {
                    b.HasOne("SamsungIssueTestProject.DataAccess.Models.Contact", "Contact")
                        .WithMany("Addresses")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SamsungIssueTestProject.DataAccess.Models.ContactEvent", b =>
                {
                    b.HasOne("SamsungIssueTestProject.DataAccess.Models.Contact", "Contact")
                        .WithMany("Events")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SamsungIssueTestProject.DataAccess.Models.ContactInfo", b =>
                {
                    b.HasOne("SamsungIssueTestProject.DataAccess.Models.Contact", "Contact")
                        .WithMany("Infos")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
