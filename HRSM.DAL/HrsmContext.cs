using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using HRSM.Models;

namespace HRSM.DAL;

public partial class HrsmContext : DbContext
{
    public HrsmContext()
    {
    }

    public HrsmContext(DbContextOptions<HrsmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CustomerFollowUpLogInfo> CustomerFollowUpLogInfos { get; set; }

    public virtual DbSet<CustomerInfo> CustomerInfos { get; set; }

    public virtual DbSet<CustomerRequestInfo> CustomerRequestInfos { get; set; }

    public virtual DbSet<HouseInfo> HouseInfos { get; set; }

    public virtual DbSet<HouseLayoutInfo> HouseLayoutInfos { get; set; }

    public virtual DbSet<HouseOwnerInfo> HouseOwnerInfos { get; set; }

    public virtual DbSet<HouseStateInfo> HouseStateInfos { get; set; }

    public virtual DbSet<HouseTradeInfo> HouseTradeInfos { get; set; }

    public virtual DbSet<MenuInfo> MenuInfos { get; set; }

    public virtual DbSet<PriceUnitInfo> PriceUnitInfos { get; set; }

    public virtual DbSet<RoleInfo> RoleInfos { get; set; }

    public virtual DbSet<RoleMenuInfo> RoleMenuInfos { get; set; }

    public virtual DbSet<UserInfo> UserInfos { get; set; }

    public virtual DbSet<UserRoleInfo> UserRoleInfos { get; set; }

    public virtual DbSet<ViewCustomerFollowUpLogInfo> ViewCustomerFollowUpLogInfos { get; set; }

    public virtual DbSet<ViewCustomerRequestInfo> ViewCustomerRequestInfos { get; set; }

    public virtual DbSet<ViewHouseCountSatistic> ViewHouseCountSatistics { get; set; }

    public virtual DbSet<ViewHouseInfo> ViewHouseInfos { get; set; }

    public virtual DbSet<ViewHouseTradeInfo> ViewHouseTradeInfos { get; set; }

    public virtual DbSet<ViewSaleHouseStatistic> ViewSaleHouseStatistics { get; set; }

    public virtual DbSet<ViewUserRoleInfo> ViewUserRoleInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=HRSMDBase;Integrated Security=True;TrustServerCertificate=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerFollowUpLogInfo>(entity =>
        {
            entity.HasKey(e => e.FlogId);

            entity.Property(e => e.FlogId).HasColumnName("FLogId");
            entity.Property(e => e.FollowUpContent).HasMaxLength(500);
            entity.Property(e => e.FollowUpState).HasMaxLength(5);
            entity.Property(e => e.FollowUpTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FollowUpUser)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CustomerInfo>(entity =>
        {
            entity.HasKey(e => e.CustomerId);

            entity.Property(e => e.Contactor).HasMaxLength(20);
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CustomerAddress).HasMaxLength(100);
            entity.Property(e => e.CustomerName).HasMaxLength(20);
            entity.Property(e => e.CustomerPhone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CustomerState)
                .HasMaxLength(5)
                .HasDefaultValue("普通客户");
            entity.Property(e => e.CustomerType).HasMaxLength(2);
            entity.Property(e => e.Remark).HasMaxLength(500);
        });

        modelBuilder.Entity<CustomerRequestInfo>(entity =>
        {
            entity.HasKey(e => e.CustRequestId);

            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FollowUpUser)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RequestContent).HasMaxLength(500);
            entity.Property(e => e.RequestState)
                .HasMaxLength(5)
                .HasDefaultValue("跟进中");
        });

        modelBuilder.Entity<HouseInfo>(entity =>
        {
            entity.HasKey(e => e.HouseId);

            entity.Property(e => e.Building).HasMaxLength(20);
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.HouseAddress).HasMaxLength(100);
            entity.Property(e => e.HouseArea).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HouseDirection).HasMaxLength(10);
            entity.Property(e => e.HouseFloor).HasDefaultValue(1);
            entity.Property(e => e.HouseLayout).HasMaxLength(20);
            entity.Property(e => e.HouseName).HasMaxLength(50);
            entity.Property(e => e.HousePic)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.HousePrice)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HouseState)
                .HasMaxLength(3)
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.PriceUnit).HasMaxLength(10);
            entity.Property(e => e.PublishTime).HasColumnType("datetime");
            entity.Property(e => e.PublishUser)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Remark).HasMaxLength(500);
            entity.Property(e => e.RentSale)
                .HasMaxLength(2)
                .HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<HouseLayoutInfo>(entity =>
        {
            entity.HasKey(e => e.Hlid);

            entity.Property(e => e.Hlid).HasColumnName("HLId");
            entity.Property(e => e.Hlname)
                .HasMaxLength(50)
                .HasColumnName("HLName");
        });

        modelBuilder.Entity<HouseOwnerInfo>(entity =>
        {
            entity.HasKey(e => e.OwnerId);

            entity.Property(e => e.Contactor).HasMaxLength(20);
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.OwnerAddress).HasMaxLength(100);
            entity.Property(e => e.OwnerName).HasMaxLength(20);
            entity.Property(e => e.OwnerPhone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.OwnerType).HasMaxLength(2);
            entity.Property(e => e.Remark).HasMaxLength(500);
        });

        modelBuilder.Entity<HouseStateInfo>(entity =>
        {
            entity.HasKey(e => e.StateId);

            entity.Property(e => e.StateId).ValueGeneratedNever();
            entity.Property(e => e.Rsid).HasColumnName("RSId");
            entity.Property(e => e.StateName).HasMaxLength(3);
        });

        modelBuilder.Entity<HouseTradeInfo>(entity =>
        {
            entity.HasKey(e => e.TradeId);

            entity.Property(e => e.DealUser)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PriceUnit).HasMaxLength(10);
            entity.Property(e => e.RentSale).HasMaxLength(2);
            entity.Property(e => e.TradeAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TradeTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TradeWay).HasMaxLength(10);
        });

        modelBuilder.Entity<MenuInfo>(entity =>
        {
            entity.HasKey(e => e.MenuId);

            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MenuName).HasMaxLength(50);
            entity.Property(e => e.MenuUrl)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Morder)
                .HasDefaultValue(1)
                .HasColumnName("MOrder");
        });

        modelBuilder.Entity<PriceUnitInfo>(entity =>
        {
            entity.HasKey(e => e.PunitId);

            entity.Property(e => e.PunitId).HasColumnName("PUnitId");
            entity.Property(e => e.PunitName)
                .HasMaxLength(5)
                .HasColumnName("PUnitName");
        });

        modelBuilder.Entity<RoleInfo>(entity =>
        {
            entity.HasKey(e => e.RoleId);

            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Remark).HasMaxLength(500);
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<RoleMenuInfo>(entity =>
        {
            entity.HasKey(e => e.Rmid);

            entity.Property(e => e.Rmid).HasColumnName("RMId");
        });

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserFname)
                .HasMaxLength(10)
                .HasColumnName("UserFName");
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UserPhone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UserPwd)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserState).HasDefaultValue(true);
        });

        modelBuilder.Entity<UserRoleInfo>(entity =>
        {
            entity.HasKey(e => e.Urid);

            entity.Property(e => e.Urid).HasColumnName("URId");
        });

        modelBuilder.Entity<ViewCustomerFollowUpLogInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViewCustomerFollowUpLogInfos");

            entity.Property(e => e.CustomerName).HasMaxLength(20);
            entity.Property(e => e.FlogId).HasColumnName("FLogId");
            entity.Property(e => e.FollowUpContent).HasMaxLength(500);
            entity.Property(e => e.FollowUpState).HasMaxLength(5);
            entity.Property(e => e.FollowUpTime).HasColumnType("datetime");
            entity.Property(e => e.FollowUpUser)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RequestContent).HasMaxLength(500);
        });

        modelBuilder.Entity<ViewCustomerRequestInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViewCustomerRequestInfos");

            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.CustomerName).HasMaxLength(20);
            entity.Property(e => e.CustomerState).HasMaxLength(5);
            entity.Property(e => e.CustomerType).HasMaxLength(2);
            entity.Property(e => e.FollowUpUser)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RequestContent).HasMaxLength(500);
            entity.Property(e => e.RequestState).HasMaxLength(5);
        });

        modelBuilder.Entity<ViewHouseCountSatistic>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViewHouseCountSatistics");

            entity.Property(e => e.TrentCount).HasColumnName("TRentCount");
            entity.Property(e => e.TsaleCount).HasColumnName("TSaleCount");
        });

        modelBuilder.Entity<ViewHouseInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViewHouseInfos");

            entity.Property(e => e.Building).HasMaxLength(20);
            entity.Property(e => e.HouseAddress).HasMaxLength(100);
            entity.Property(e => e.HouseArea).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HouseDirection).HasMaxLength(10);
            entity.Property(e => e.HouseLayout).HasMaxLength(20);
            entity.Property(e => e.HouseName).HasMaxLength(50);
            entity.Property(e => e.HousePic)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.HousePrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HouseState).HasMaxLength(3);
            entity.Property(e => e.OwnerName).HasMaxLength(20);
            entity.Property(e => e.OwnerPhone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PriceUnit).HasMaxLength(10);
            entity.Property(e => e.Remark).HasMaxLength(500);
            entity.Property(e => e.RentSale).HasMaxLength(2);
        });

        modelBuilder.Entity<ViewHouseTradeInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViewHouseTradeInfos");

            entity.Property(e => e.Building).HasMaxLength(20);
            entity.Property(e => e.CustomerAddress).HasMaxLength(100);
            entity.Property(e => e.CustomerName).HasMaxLength(20);
            entity.Property(e => e.CustomerPhone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DealUser)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.HouseAddress).HasMaxLength(100);
            entity.Property(e => e.HouseArea).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HouseDirection).HasMaxLength(10);
            entity.Property(e => e.HouseLayout).HasMaxLength(20);
            entity.Property(e => e.HouseName).HasMaxLength(50);
            entity.Property(e => e.HousePrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.OwnerName).HasMaxLength(20);
            entity.Property(e => e.OwnerPhone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PriceUnit).HasMaxLength(10);
            entity.Property(e => e.RentSale).HasMaxLength(2);
            entity.Property(e => e.TradeAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TradeTime).HasColumnType("datetime");
            entity.Property(e => e.TradeWay).HasMaxLength(10);
        });

        modelBuilder.Entity<ViewSaleHouseStatistic>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViewSaleHouseStatistics");

            entity.Property(e => e.DealUser)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UserFname)
                .HasMaxLength(10)
                .HasColumnName("UserFName");
        });

        modelBuilder.Entity<ViewUserRoleInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViewUserRoleInfos");

            entity.Property(e => e.RoleName).HasMaxLength(50);
            entity.Property(e => e.UserFname)
                .HasMaxLength(10)
                .HasColumnName("UserFName");
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UserPhone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UserPwd)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
