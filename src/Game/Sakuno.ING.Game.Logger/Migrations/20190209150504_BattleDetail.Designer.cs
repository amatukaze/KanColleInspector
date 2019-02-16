﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sakuno.ING.Game.Logger;

namespace Sakuno.ING.Game.Logger.Migrations
{
    [DbContext(typeof(LoggerContextBase))]
    [Migration("20190209150504_BattleDetail")]
    partial class BattleDetail
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity("Sakuno.ING.Game.Logger.Entities.Combat.BattleDetailEntity", b =>
                {
                    b.Property<long>("TimeStamp");

                    b.Property<byte[]>("FirstBattleDetail");

                    b.Property<byte[]>("LandBaseDefence");

                    b.Property<byte[]>("LbasState");

                    b.Property<byte[]>("SecondBattleDetail");

                    b.Property<byte[]>("SortieFleet2State");

                    b.Property<byte[]>("SortieFleetState");

                    b.Property<string>("Source");

                    b.Property<byte[]>("SupportFleetState");

                    b.HasKey("TimeStamp");

                    b.ToTable("BattleDetailEntity");
                });

            modelBuilder.Entity("Sakuno.ING.Game.Logger.Entities.Combat.BattleEntity", b =>
                {
                    b.Property<long>("TimeStamp");

                    b.Property<int?>("AdmiralExperience");

                    b.Property<int?>("BaseExperience");

                    b.Property<int>("BattleKind");

                    b.Property<string>("EnemyFleetName");

                    b.Property<int>("EventKind");

                    b.Property<bool?>("MapCleared");

                    b.Property<int?>("MapGaugeHP");

                    b.Property<int?>("MapGaugeMaxHP");

                    b.Property<int?>("MapGaugeNumber");

                    b.Property<int?>("MapGaugeType");

                    b.Property<int>("MapId");

                    b.Property<string>("MapName");

                    b.Property<int?>("MapRank");

                    b.Property<int?>("Rank");

                    b.Property<int>("RouteId");

                    b.Property<int?>("ShipDropped");

                    b.Property<string>("Source");

                    b.Property<int?>("UseItemAcquired");

                    b.HasKey("TimeStamp");

                    b.HasIndex("MapId");

                    b.ToTable("BattleTable");
                });

            modelBuilder.Entity("Sakuno.ING.Game.Logger.Entities.Combat.JNameEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("JNameTable");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = ""
                        });
                });

            modelBuilder.Entity("Sakuno.ING.Game.Logger.Entities.EquipmentCreationEntity", b =>
                {
                    b.Property<long>("TimeStamp");

                    b.Property<int>("AdmiralLevel");

                    b.Property<int>("Consumption_Bauxite");

                    b.Property<int>("Consumption_Bullet");

                    b.Property<int>("Consumption_Fuel");

                    b.Property<int>("Consumption_Steel");

                    b.Property<int>("EquipmentCreated");

                    b.Property<bool>("IsSuccess");

                    b.Property<int>("Secretary");

                    b.Property<int>("SecretaryLevel");

                    b.Property<string>("Source");

                    b.HasKey("TimeStamp");

                    b.ToTable("EquipmentCreationTable");
                });

            modelBuilder.Entity("Sakuno.ING.Game.Logger.Entities.ExpeditionCompletionEntity", b =>
                {
                    b.Property<long>("TimeStamp");

                    b.Property<int>("ExpeditionId");

                    b.Property<string>("ExpeditionName");

                    b.Property<int>("MaterialsAcquired_Bauxite");

                    b.Property<int>("MaterialsAcquired_Bullet");

                    b.Property<int>("MaterialsAcquired_Fuel");

                    b.Property<int>("MaterialsAcquired_Steel");

                    b.Property<int>("Result");

                    b.Property<int?>("RewardItem1_Count");

                    b.Property<int?>("RewardItem1_ItemId");

                    b.Property<int?>("RewardItem2_Count");

                    b.Property<int?>("RewardItem2_ItemId");

                    b.Property<string>("Source");

                    b.HasKey("TimeStamp");

                    b.ToTable("ExpeditionCompletionTable");
                });

            modelBuilder.Entity("Sakuno.ING.Game.Logger.Entities.ShipCreationEntity", b =>
                {
                    b.Property<long>("TimeStamp");

                    b.Property<int>("AdmiralLevel");

                    b.Property<int>("Consumption_Bauxite");

                    b.Property<int>("Consumption_Bullet");

                    b.Property<int>("Consumption_Development");

                    b.Property<int>("Consumption_Fuel");

                    b.Property<int>("Consumption_Steel");

                    b.Property<int>("EmptyDockCount");

                    b.Property<bool>("IsLSC")
                        .HasColumnName("ConstructionType");

                    b.Property<int>("Secretary");

                    b.Property<int>("SecretaryLevel");

                    b.Property<int>("ShipBuilt");

                    b.Property<string>("Source");

                    b.HasKey("TimeStamp");

                    b.ToTable("ShipCreationTable");
                });

            modelBuilder.Entity("Sakuno.ING.Game.Logger.Entities.Combat.BattleDetailEntity", b =>
                {
                    b.HasOne("Sakuno.ING.Game.Logger.Entities.Combat.BattleEntity")
                        .WithOne("Details")
                        .HasForeignKey("Sakuno.ING.Game.Logger.Entities.Combat.BattleDetailEntity", "TimeStamp")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}