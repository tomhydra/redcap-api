using Newtonsoft.Json;
using Redcap;
using Redcap.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace RedcapApiTests
{
    [TestFixture]
    public class ApiMethodTests
    {
        
        private string _apiKey = "3D57A7FA57C8A43F6C8803A84BB3957B";
        private string _apiEndpoint = "http://localhost/redcap/api/";
        public ApiMethodTests()
        {
            
            if (true) _apiKey = "BCC9D1F214B8BE2AA4F24C56ED7674E4";
        }
        [TestCase]
        public void CanExportAsync_SingleRecord_ShouldContain_string_1()
        {
            // Arrange
            var apiKey = _apiKey;
            var apiEndpoint = _apiEndpoint;
            
            // Act
            var redcap_api = new RedcapApi(apiKey, apiEndpoint);
            var result = redcap_api.GetRecordAsync("1", InputFormat.json, RedcapDataType.flat, ReturnFormat.json, null, null, null, null).Result;
            var data = JsonConvert.DeserializeObject(result).ToString();

            // Assert
            StringAssert.Contains("1", data);
        }
        [TestCase]
        public void CanExportAsync_AllEvents_ShouldContain_event_name()
        {
            // Arrange
            var apiKey = _apiKey;
            var apiEndpoint = _apiEndpoint;

            // Act
            var redcap_api = new RedcapApi(apiKey, apiEndpoint);
            var result = redcap_api.ExportEventsAsync(InputFormat.json, ReturnFormat.json).Result;
            var data = JsonConvert.DeserializeObject(result).ToString();

            // Assert
            StringAssert.Contains("event_name", data);

        }
        [TestCase]
        public void CanGetRecordsAsync1_AllRecords_ShouldContain_string_record_id()
        {
            // Arrange
            var apiKey = _apiKey;
            var apiEndpoint = _apiEndpoint;

            // Act
            var redcap_api = new RedcapApi(apiKey, apiEndpoint);
            var result = redcap_api.GetRecordsAsync(InputFormat.json, ReturnFormat.json, RedcapDataType.flat).Result;
            var data = JsonConvert.DeserializeObject(result).ToString();

            // Assert
            StringAssert.Contains("record_id", data);

        }

        [TestCase]
        public void CanGetRecordsAsync2_AllRecords_ShouldContain_string_record_id()
        {
            // Arrange
            var apiKey = _apiKey;
            var apiEndpoint = _apiEndpoint;
            char[] delimiters = new char[] { ';', ',' };

            // Act
            var redcap_api = new RedcapApi(apiKey, apiEndpoint);
            var result = redcap_api.GetRecordsAsync(InputFormat.json, ReturnFormat.json, RedcapDataType.flat, delimiters).Result;
            var data = JsonConvert.DeserializeObject(result).ToString();

            // Assert
            StringAssert.Contains("record_id", data);

        }

        [TestCase]
        public void CanGetRedcapVersion_VersionNumber_Shouldontain_Number()
        {
            // Arrange
            // Assume current redcap version is 7.4.10
            var currentRedcapVersion = "7.4.10";
            var apiKey = _apiKey;
            var apiEndpoint = _apiEndpoint;

            // Act
            var redcap_api = new RedcapApi(apiKey, apiEndpoint);
            var result = redcap_api.GetRedcapVersionAsync(InputFormat.json, RedcapDataType.flat).Result;
            var data = result;

            // Assert
            Assert.AreEqual(currentRedcapVersion, data);

        }

        [TestCase]
        public void CanExportRedcapVersion_VersionNumber_Shouldontain_Number()
        {
            // Arrange
            // Assume current redcap version is 7.4.10
            var currentRedcapVersion = "7.4.10";
            var apiKey = _apiKey;
            var apiEndpoint = _apiEndpoint;

            // Act
            var redcap_api = new RedcapApi(apiKey, apiEndpoint);
            var result = redcap_api.ExportRedcapVersionAsync(InputFormat.json, RedcapDataType.flat).Result;
            var data = result;

            // Assert
            Assert.AreEqual(currentRedcapVersion, data);

        }

        [TestCase]
        public void CanExportUsers_AllUsers_ShouldReturn_username()
        {
            // Arrange
            var apiKey = _apiKey;
            var apiEndpoint = _apiEndpoint;
            var username = "site_admin";
            // Act
            var redcap_api = new RedcapApi(apiKey, apiEndpoint);
            var result = redcap_api.ExportUsersAsync(InputFormat.json, ReturnFormat.json).Result;
            var data = result;

            // Assert
            StringAssert.Contains(username, data);

        }

        [TestCase]
        public void CanSaveRecord1_SingleRecord_ShouldReturn_Ids()
        {
            // Arrange
            var apiKey = _apiKey;
            var apiEndpoint = _apiEndpoint;

            var record = new
            {
                record_id = "1",
                redcap_event_name = "event_1_arm_1",
                first_name = "John",
                last_name = "Doe"
            };
            // Act
            var redcap_api = new RedcapApi(apiKey, apiEndpoint);
            var result = redcap_api.SaveRecordsAsync(record, ReturnContent.ids, OverwriteBehavior.overwrite, InputFormat.json, RedcapDataType.flat, ReturnFormat.json).Result;
            var data = JsonConvert.DeserializeObject(result).ToString();

            // Assert
            StringAssert.Contains("1", data);

        }

        [TestCase]
        public void CanSaveRecord2_SingleRecord_ShouldReturn_Ids()
        {
            // Arrange
            var apiKey = _apiKey;
            var apiEndpoint = _apiEndpoint;
            var dateFormat = "YMD";
            var record = new
            {
                record_id = "1",
                redcap_event_name = "event_1_arm_1",
                first_name = "John",
                last_name = "Doe"
            };

            // Act
            var redcap_api = new RedcapApi(apiKey, apiEndpoint);
            var result = redcap_api.SaveRecordsAsync(record, ReturnContent.ids, OverwriteBehavior.overwrite, InputFormat.json, RedcapDataType.flat, ReturnFormat.json, dateFormat).Result;
            var data = JsonConvert.DeserializeObject(result).ToString();

            // Assert
            StringAssert.Contains("1", data);

        }

        [TestCase]
        public void CanExportRecordsAsync_AllRecords_ShouldReturn_string_record_id()
        {
            // Arrange
            var apiKey = _apiKey;
            var apiEndpoint = _apiEndpoint;

            // Act
            var redcap_api = new RedcapApi(apiKey, apiEndpoint);
            var result = redcap_api.ExportRecordsAsync(InputFormat.json, RedcapDataType.flat).Result;
            var data = JsonConvert.DeserializeObject(result).ToString();

            // Assert
            StringAssert.Contains("record_id", data);
        }
        [TestCase]
        public void CanExportMetaDataAsync_Metadata_ShouldReturn_string_record_id()
        {
            // Arrange
            var apiKey = _apiKey;
            var apiEndpoint = _apiEndpoint;

            // Act
            var redcap_api = new RedcapApi(apiKey, apiEndpoint);
            var result = redcap_api.ExportMetaDataAsync(InputFormat.json, ReturnFormat.json).Result;
            var data = JsonConvert.DeserializeObject(result).ToString();

            // Assert
            StringAssert.Contains("record_id", data);
        }
        [TestCase]
        public void CanExportArmsAsync_Arms_ShouldReturn_arms_array()
        {
            // Arrange
            var apiKey = _apiKey;
            var apiEndpoint = _apiEndpoint;
            var listOfArms = new List<string> { };
            // Act
            var redcap_api = new RedcapApi(apiKey, apiEndpoint);
            var result = redcap_api.ExportArmsAsync(InputFormat.json, ReturnFormat.json, listOfArms).Result;
            var data = JsonConvert.DeserializeObject(result).ToString();

            // Assert
            StringAssert.Contains("event_1_arm_1", data);
        }

    }
}
