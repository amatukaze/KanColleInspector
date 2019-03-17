﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sakuno.ING.Game.Logger;

namespace Sakuno.ING.Game.Logger.Migrations
{
    [DbContext(typeof(LoggerContext))]
    [Migration("20180720052302_ResetModel")]
    partial class ResetModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846");

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
#pragma warning restore 612, 618
        }
    }
}