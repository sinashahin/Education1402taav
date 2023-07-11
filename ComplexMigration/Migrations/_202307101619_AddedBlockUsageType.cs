using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexMigration.Migrations
{
    [Migration(202307101619)]
    public class _202307101619_AddedBlockUsageType : FluentMigrator.Migration
    {
        public override void Up()
        {
            Create.Table("BlookUsageTypes")
                .WithColumn("BlookId").AsInt32().PrimaryKey().
                ForeignKey("FK_BlookUsageTypes_Blooks", "Blooks", "Id")
                .WithColumn("UsageTypeId").AsInt32().PrimaryKey()
                .ForeignKey("FK_BlookUsageTypes_UsageTypes", "UsageTypes", "Id");
        }
        public override void Down()
        {
            Delete.Table("BlookUsageTypes");
        }


    }
}
