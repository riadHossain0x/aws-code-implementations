using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoDB.Console
{
	[DynamoDBTable("riad_table")]
	public class Student
    {
		[DynamoDBHashKey] //Partition key
		public int Id
		{
			get; set;
		}
		[DynamoDBProperty]
		public string Name
		{
			get; set;
		}
		[DynamoDBProperty]
		public int Age
		{
			get; set;
		}

		[DynamoDBProperty]
		public string Department
        {
			get; set;
        }
	}
}
