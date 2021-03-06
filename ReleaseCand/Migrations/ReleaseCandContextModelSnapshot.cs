﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReleaseCand.Models;

namespace ReleaseCand.Migrations
{
    [DbContext(typeof(ReleaseCandContext))]
    partial class ReleaseCandContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReleaseCand.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CustomerDate");

                    b.Property<int>("NumOfGuests");

                    b.HasKey("CustomerID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("ReleaseCand.Models.OnOrd", b =>
                {
                    b.Property<int>("OnOrdID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BillAddress");

                    b.Property<string>("BillCity");

                    b.Property<string>("BillState");

                    b.Property<string>("BillZip")
                        .HasMaxLength(5);

                    b.Property<string>("CCV")
                        .HasMaxLength(3);

                    b.Property<bool>("CheeseBurger");

                    b.Property<bool>("CheeseCake");

                    b.Property<string>("CreditCardNum");

                    b.Property<string>("Email");

                    b.Property<DateTime>("ExpDate");

                    b.Property<string>("FirstName");

                    b.Property<bool>("FrenchFries");

                    b.Property<bool>("Lasagna");

                    b.Property<string>("LastName");

                    b.Property<bool>("Pepsi");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(14);

                    b.Property<bool>("Sprite");

                    b.Property<bool>("TiriMisu");

                    b.Property<bool>("Water");

                    b.HasKey("OnOrdID");

                    b.ToTable("OnOrd");
                });

            modelBuilder.Entity("ReleaseCand.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CustomerDate");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("NumOfGuests");

                    b.Property<string>("Other");

                    b.Property<int>("PhoneNumber");

                    b.Property<string>("Reasons");

                    b.Property<string>("SpecialRequests");

                    b.HasKey("ReservationID");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("ReleaseCand.ViewModels.CustomerReportViewModel", b =>
                {
                    b.Property<int>("CustomerReportViewModelID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CustomerDate");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("NumOfGuests");

                    b.Property<string>("Other");

                    b.Property<int>("PhoneNumber");

                    b.Property<string>("Reasons");

                    b.Property<string>("SpecialRequests");

                    b.HasKey("CustomerReportViewModelID");

                    b.ToTable("CustomerReportViewModel");
                });
#pragma warning restore 612, 618
        }
    }
}
