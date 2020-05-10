using System;
using System.Collections.Generic;
using IdentityServer4.Admin.Entities;

namespace IdentityServer4.Admin.Infrastructure
{
    public static class BaseRoleList
    {
        public static readonly List<Role> RoleList = new List<Role>
        {
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "SuperAdministrator",
                BranchId = 0,
                NormalizedName = "SUPERADMINISTRATOR"
            },

            #region ERP

            

            
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "Erp",
                NormalizedName = "ERP",
                BranchId = 0,
                Description = "ERP用户"
            },
           
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "BranchOwner",
                NormalizedName = "BRANCHOWNER",
                BranchId = 0,
                Description = "系统管理员"
            },

            new Role
            {
                Id = Guid.NewGuid(),
                Name = "Cashier",
                NormalizedName = "CASHIER",
                BranchId = 0,
                Description = "出纳"
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "Accounting",
                Description = "会计",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "IncomeAccounting",
                Description = "应收会计",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Description = "应付会计",
                Name = "OutcomeAccounting",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "FinancialManager",
                Description = "财务经理",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "Purchaser",
                Description = "采购员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "PurchaserManager",
                Description = "采购经理",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "Salesman",
                Description = "销售员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "DirectExpressOrderMaker",
                Description = "直发下单员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "Dispenser",
                Description = "配货员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "Consignee",
                Description = "收货员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "StockOut",
                Description = "出库员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "WarehouseManager",
                Description = "仓库经理",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "OrderDeliver",
                Description = "分单员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "StockStuff",
                Description = "仓管员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "DirectExpressArchiver",
                Description = "直发归档员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "OrderAuditor",
                Description = "订单审核员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "DistributionCheckingCollector",
                Description = "分销对账收款员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "DistributionManager",
                Description = "分销管理员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "DistributionCheckingTeller",
                Description = "分销对账付款员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "APIManager",
                Description = "接口管理员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "CostManager",
                Description = "成本管理员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "DraftOrderManager",
                Description = "草稿单管理员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "StockManager",
                Description = "库存管理员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "CustomerService",
                Description = "客服",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "CustomerServiceManager",
                Description = "客服经理",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERPMallManager",
                Description = "商城管理员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "GoodsManager",
                Description = "商品管理员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "GoodsOnShelfManager",
                Description = "新增商品员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "Business",
                Description = "商务",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "After-salesManager",
                Description = "售后专员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "Deliveryman",
                Description = "送货员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "LogisticsManager",
                Description = "物流经理",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "SalesManager",
                Description = "销售经理",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "SalesDirector",
                Description = "销售总监",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ProductOperator",
                Description = "产品运营",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "AccountPeriodManager",
                Description = "账期管理员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERPManager",
                Description = "总经理",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "ERPManagerAssistant",
                Description = "总经理助理",
                BranchId = 0
            },

            #endregion

            #region 商城

            

           
            //商城
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "Mall",
                NormalizedName = "MALL",
                BranchId = 0,
                Description = "商城用户"
            },
            
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "MallManager",
                Description = "系统管理员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "MallPurchaseManager",
                Description = "采购管理员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "MallDepartmentManager",
                Description = "部门管理员",
                BranchId = 0
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "MallFinancialManager",
                Description = "财务管理员",
                BranchId = 0
            },
            #endregion
        };
    }
}