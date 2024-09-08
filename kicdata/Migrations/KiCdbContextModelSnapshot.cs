﻿// <auto-generated />
using System;
using KiCData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KiCData.Migrations
{
    [DbContext(typeof(KiCdbContext))]
    partial class KiCdbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("GroupUser", b =>
                {
                    b.Property<Guid>("GroupsId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("char(36)");

                    b.HasKey("GroupsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("GroupUser");
                });

            modelBuilder.Entity("KiCData.Models.Attendee", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<bool>("BackgroundChecked")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("BadgeName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ConfirmationNumber")
                        .HasColumnType("int");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("Pronouns")
                        .HasColumnType("longtext");

                    b.Property<string>("RoomPreference")
                        .HasColumnType("longtext");

                    b.Property<bool>("RoomWaitListed")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("TicketId")
                        .HasColumnType("int");

                    b.Property<bool>("TicketWaitListed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("isRegistered")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("MemberId")
                        .IsUnique();

                    b.HasIndex("TicketId")
                        .IsUnique();

                    b.ToTable("Attendee");
                });

            modelBuilder.Entity("KiCData.Models.ClubMember", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("ClubId")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("DateOfBirth")
                        .IsRequired()
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ClubMember");
                });

            modelBuilder.Entity("KiCData.Models.Event", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<DateOnly?>("EndDate")
                        .HasColumnType("date");

                    b.Property<string>("ImagePath")
                        .HasColumnType("longtext");

                    b.Property<string>("Link")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<DateOnly?>("StartDate")
                        .HasColumnType("date");

                    b.Property<string>("Topic")
                        .HasColumnType("longtext");

                    b.Property<int?>("VenueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VenueId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("KiCData.Models.EventVendor", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int>("ConfirmationNumber")
                        .HasColumnType("int");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("VendorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("VendorId");

                    b.ToTable("EventVendor");
                });

            modelBuilder.Entity("KiCData.Models.EventVolunteer", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("Position")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ShiftEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ShiftStart")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("VolunteerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("VolunteerId");

                    b.ToTable("EventVolunteer");
                });

            modelBuilder.Entity("KiCData.Models.Group", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("KiCData.Models.Member", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("AdditionalInfo")
                        .HasColumnType("longtext");

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<int?>("ClubId")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("DateOfBirth")
                        .IsRequired()
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FetName")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<int?>("PresenterId")
                        .HasColumnType("int");

                    b.Property<int?>("PublicId")
                        .HasColumnType("int");

                    b.Property<string>("SexOnID")
                        .HasColumnType("longtext");

                    b.Property<string>("State")
                        .HasColumnType("longtext");

                    b.Property<int?>("VendorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PresenterId");

                    b.HasIndex("VendorId");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("KiCData.Models.PendingVolunteer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("EventId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PreferredPositions")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("PendingVolunteers");
                });

            modelBuilder.Entity("KiCData.Models.Presentation", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("ImgPath")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PresenterId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("PresenterId");

                    b.ToTable("Presentation");
                });

            modelBuilder.Entity("KiCData.Models.Presenter", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Bio")
                        .HasColumnType("longtext");

                    b.Property<string>("Details")
                        .HasColumnType("longtext");

                    b.Property<decimal?>("Fee")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("ImgPath")
                        .HasColumnType("longtext");

                    b.Property<DateOnly?>("LastAttended")
                        .HasColumnType("date");

                    b.Property<string>("PublicName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Requests")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Presenter");
                });

            modelBuilder.Entity("KiCData.Models.Staff", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int?>("MemberId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MemberId")
                        .IsUnique();

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("KiCData.Models.Ticket", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<DateOnly?>("DatePurchased")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("EndDate")
                        .HasColumnType("date");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsComped")
                        .HasColumnType("tinyint(1)");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<DateOnly?>("StartDate")
                        .HasColumnType("date");

                    b.Property<string>("Type")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("KiCData.Models.TicketComp", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("AuthorizingUser")
                        .HasColumnType("longtext");

                    b.Property<double?>("CompAmount")
                        .HasColumnType("double");

                    b.Property<double?>("CompPct")
                        .HasColumnType("double");

                    b.Property<string>("CompReason")
                        .HasColumnType("longtext");

                    b.Property<string>("DiscountCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("TicketId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.ToTable("TicketComp");
                });

            modelBuilder.Entity("KiCData.Models.User", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Token")
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MemberId")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("KiCData.Models.Vendor", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ImgPath")
                        .HasColumnType("longtext");

                    b.Property<DateOnly?>("LastAttended")
                        .HasColumnType("date");

                    b.Property<string>("MerchType")
                        .HasColumnType("longtext");

                    b.Property<decimal?>("PriceAvg")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal?>("PriceMax")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal?>("PriceMin")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("PublicName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Vendor");
                });

            modelBuilder.Entity("KiCData.Models.Venue", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float?>("Cost")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Venue");
                });

            modelBuilder.Entity("KiCData.Models.Volunteer", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Details")
                        .HasColumnType("longtext");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("Positions")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MemberId")
                        .IsUnique();

                    b.ToTable("Volunteer");
                });

            modelBuilder.Entity("KiCData.Models.WaitList", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int>("AttendeeId")
                        .HasColumnType("int");

                    b.Property<string>("Comments")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("SubmissionDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("AttendeeId");

                    b.ToTable("WaitList");
                });

            modelBuilder.Entity("GroupUser", b =>
                {
                    b.HasOne("KiCData.Models.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KiCData.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KiCData.Models.Attendee", b =>
                {
                    b.HasOne("KiCData.Models.Member", "Member")
                        .WithOne("Attendee")
                        .HasForeignKey("KiCData.Models.Attendee", "MemberId");

                    b.HasOne("KiCData.Models.Ticket", "Ticket")
                        .WithOne("Attendee")
                        .HasForeignKey("KiCData.Models.Attendee", "TicketId");

                    b.Navigation("Member");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("KiCData.Models.Event", b =>
                {
                    b.HasOne("KiCData.Models.Venue", "Venue")
                        .WithMany()
                        .HasForeignKey("VenueId");

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("KiCData.Models.EventVendor", b =>
                {
                    b.HasOne("KiCData.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KiCData.Models.Vendor", "Vendor")
                        .WithMany()
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("KiCData.Models.EventVolunteer", b =>
                {
                    b.HasOne("KiCData.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId");

                    b.HasOne("KiCData.Models.Volunteer", "Volunteer")
                        .WithMany()
                        .HasForeignKey("VolunteerId");

                    b.Navigation("Event");

                    b.Navigation("Volunteer");
                });

            modelBuilder.Entity("KiCData.Models.Member", b =>
                {
                    b.HasOne("KiCData.Models.Presenter", "Presenter")
                        .WithMany("Members")
                        .HasForeignKey("PresenterId");

                    b.HasOne("KiCData.Models.Vendor", "Vendor")
                        .WithMany("Members")
                        .HasForeignKey("VendorId");

                    b.Navigation("Presenter");

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("KiCData.Models.PendingVolunteer", b =>
                {
                    b.HasOne("KiCData.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("KiCData.Models.Presentation", b =>
                {
                    b.HasOne("KiCData.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KiCData.Models.Presenter", "Presenter")
                        .WithMany()
                        .HasForeignKey("PresenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Presenter");
                });

            modelBuilder.Entity("KiCData.Models.Staff", b =>
                {
                    b.HasOne("KiCData.Models.Member", "Member")
                        .WithOne("Staff")
                        .HasForeignKey("KiCData.Models.Staff", "MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("KiCData.Models.Ticket", b =>
                {
                    b.HasOne("KiCData.Models.Event", "Event")
                        .WithMany("Tickets")
                        .HasForeignKey("EventId");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("KiCData.Models.TicketComp", b =>
                {
                    b.HasOne("KiCData.Models.Ticket", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketId");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("KiCData.Models.User", b =>
                {
                    b.HasOne("KiCData.Models.Member", "Member")
                        .WithOne("User")
                        .HasForeignKey("KiCData.Models.User", "MemberId");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("KiCData.Models.Volunteer", b =>
                {
                    b.HasOne("KiCData.Models.Member", "Member")
                        .WithOne("Volunteer")
                        .HasForeignKey("KiCData.Models.Volunteer", "MemberId");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("KiCData.Models.WaitList", b =>
                {
                    b.HasOne("KiCData.Models.Attendee", "Attendee")
                        .WithMany()
                        .HasForeignKey("AttendeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attendee");
                });

            modelBuilder.Entity("KiCData.Models.Event", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("KiCData.Models.Member", b =>
                {
                    b.Navigation("Attendee");

                    b.Navigation("Staff");

                    b.Navigation("User");

                    b.Navigation("Volunteer");
                });

            modelBuilder.Entity("KiCData.Models.Presenter", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("KiCData.Models.Ticket", b =>
                {
                    b.Navigation("Attendee");
                });

            modelBuilder.Entity("KiCData.Models.Vendor", b =>
                {
                    b.Navigation("Members");
                });
#pragma warning restore 612, 618
        }
    }
}
