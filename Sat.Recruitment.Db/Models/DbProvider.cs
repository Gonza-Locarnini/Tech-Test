using LiteDB;
using Sat.Recruitment.Db.Models;

public static class DbProvider
{
	public static LiteDatabase Db { get; }
	static DbProvider()
	{
		var path = ProjectSource.ProjectDirectory();
		Db = new LiteDatabase(
			new ConnectionString { 
				Filename = path + "/../Resources/Database.db",
				Connection = ConnectionType.Direct
			}
		);
	}
}