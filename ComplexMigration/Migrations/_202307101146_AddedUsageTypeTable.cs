using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexMigration.Migrations
{
    [Migration(202307101146)]
    public class _202307101146_AddedUsageTypeTable : FluentMigrator.Migration
    {
        public override void Up()
        {
            Create.Table("UsageTypes")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable();
        }
        public override void Down()
        {
            Delete.Table("UsageTypes");
        }


    }
}
