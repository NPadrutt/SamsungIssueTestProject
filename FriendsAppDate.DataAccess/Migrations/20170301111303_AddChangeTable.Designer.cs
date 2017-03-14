﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using FriendsAppDate.DataAccess;

namespace FriendsAppDate.DataAccess.Migrations
{
    [DbContext(typeof(FadContext))]
    [Migration("20170301111303_AddChangeTable")]
    partial class AddChangeTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("FriendsAppDate.DataAccess.Models.Change", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ChangeText");

                    b.Property<string>("ContactName");

                    b.HasKey("Id");

                    b.ToTable("Changes");
                });

            modelBuilder.Entity("FriendsAppDate.DataAccess.Models.Contact", b =>
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

            modelBuilder.Entity("FriendsAppDate.DataAccess.Models.ContactAddress", b =>
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

            modelBuilder.Entity("FriendsAppDate.DataAccess.Models.ContactEvent", b =>
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

            modelBuilder.Entity("FriendsAppDate.DataAccess.Models.ContactInfo", b =>
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

            modelBuilder.Entity("FriendsAppDate.DataAccess.Models.Request", b =>
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

            modelBuilder.Entity("FriendsAppDate.DataAccess.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("IdService");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FriendsAppDate.DataAccess.Models.Contact", b =>
                {
                    b.HasOne("FriendsAppDate.DataAccess.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FriendsAppDate.DataAccess.Models.ContactAddress", b =>
                {
                    b.HasOne("FriendsAppDate.DataAccess.Models.Contact", "Contact")
                        .WithMany("Addresses")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FriendsAppDate.DataAccess.Models.ContactEvent", b =>
                {
                    b.HasOne("FriendsAppDate.DataAccess.Models.Contact", "Contact")
                        .WithMany("Events")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FriendsAppDate.DataAccess.Models.ContactInfo", b =>
                {
                    b.HasOne("FriendsAppDate.DataAccess.Models.Contact", "Contact")
                        .WithMany("Infos")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
