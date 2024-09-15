using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace TmxTmDatabase
{
	public class TmxTmDb
	{
		private string _url = "mongodb://localhost:27017";

		/// <summary>
		/// Insert a TMX file (which is up to 2GB to MongoDb TmxTmDatabase.
		/// In case the files size > 2GB, an error will be thrown
		/// </summary>
		public async Task InsertFile(string filePath)
		{
			try
			{
				var client = new MongoClient(_url);
				// If TmxTmDatabase does not exists, it is created automatically
				var db = client.GetDatabase("TmxTmDatabase");
				var bucket = new GridFSBucket(db);

				var fileBytes = File.ReadAllBytes(filePath);
				var fileName = Path.GetFileNameWithoutExtension(filePath);
				var id = await bucket.UploadFromBytesAsync(fileName, fileBytes, null);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		/// <summary>
		/// Remove TMX file from the MongoDb TmxTmDatabase
		/// </summary>
		public void RemoveFile(string filePath)
		{
			var client = new MongoClient(_url);
			// If TmxTmDatabase does not exists, it is created automatically
			var db = client.GetDatabase("TmxTmDatabase");
		}
	}
}