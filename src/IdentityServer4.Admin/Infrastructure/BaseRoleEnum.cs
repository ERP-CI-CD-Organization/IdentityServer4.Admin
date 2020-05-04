using System.Collections.Generic;

namespace IdentityServer4.Admin.Infrastructure
{
    public static class BaseRoleList
    {
       
        public static  List<string> RoleList = new List<string>()
        {
            "Administrator","系统管理员","销售员","采购员",
            "出纳","会计","应收会计","应付会计","财务经理","采购经理","直发下单员",
            "配货员","收货员","出库员","仓库经理","分单员","仓管员","直发归档员",
            "订单审核员",
            "分销对账收款员","分销管理员","分销对账付款员",
            "接口管理员","成本管理员","草稿单管理员",
            "库存管理员",
            "客服","客服经理",
            "商城管理员","商品管理员","新增商品员",
            "商务",
            "售后专员",
            "送货员","物流经理",
            "销售经理","销售总监",
            "产品运营",
            "账期管理员",
            "总经理","总经理助理"

        };
        
    }
}
