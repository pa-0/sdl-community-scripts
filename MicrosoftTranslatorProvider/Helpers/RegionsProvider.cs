﻿using System.Collections.Generic;
using MicrosoftTranslatorProvider.Model;

namespace MicrosoftTranslatorProvider.Helpers
{
	public static class RegionsProvider
    {
		public static List<AccountRegion> GetSubscriptionRegions()
		{
			var regions = new List<AccountRegion>
			{
				new() {Name = string.Empty, DisplayName = "None"},
				new() {Name = "asia", DisplayName = "Asia"},
				new() {Name = "asiapacific", DisplayName = "Asia Pacific"},
				new() {Name = "australia", DisplayName = "Australia"},
				new() {Name = "australiacentral", DisplayName = "Australia Central"},
				new() {Name = "australiacentral2", DisplayName = "Australia Central 2"},
				new() {Name = "australiaeast", DisplayName = "Australia East"},
				new() {Name = "australiasoutheast", DisplayName = "Australia Southeast"},
				new() {Name = "brazil", DisplayName = "Brazil"},
				new() {Name = "brazilsouth", DisplayName = "Brazil South"},
				new() {Name = "brazilsoutheast", DisplayName = "Brazil Southeast"},
				new() {Name = "canada", DisplayName = "Canada"},
				new() {Name = "canadacentral", DisplayName = "Canada Central"},
				new() {Name = "canadaeast", DisplayName = "Canada East"},
				new() {Name = "centralindia", DisplayName = "Central India"},
				new() {Name = "centralus", DisplayName = "Central US"},
				new() {Name = "centraluseuap", DisplayName = "Central US EUAP"},
				new() {Name = "eastasia", DisplayName = "East Asia"},
				new() {Name = "eastus", DisplayName = "East US"},
				new() {Name = "eastus2", DisplayName = "East US 2"},
				new() {Name = "eastus2euap", DisplayName = "East US 2 EUAP"},
				new() {Name = "eastusstg", DisplayName = "East US STG"},
				new() {Name = "europe", DisplayName = "Europe"},
				new() {Name = "france", DisplayName = "France"},
				new() {Name = "francecentral", DisplayName = "France Central"},
				new() {Name = "francesouth", DisplayName = "France South"},
				new() {Name = "germany", DisplayName = "Germany"},
				new() {Name = "germanynorth", DisplayName = "Germany North"},
				new() {Name = "germanywestcentral", DisplayName = "Germany West Central"},
				new() {Name = "global", DisplayName = "Global"},
				new() {Name = "india", DisplayName = "India"},
				new() {Name = "japan", DisplayName = "Japan"},
				new() {Name = "japaneast", DisplayName = "Japan East"},
				new() {Name = "japanwest", DisplayName = "Japan West"},
				new() {Name = "jioindiacentral", DisplayName = "Jio India Central"},
				new() {Name = "jioindiawest", DisplayName = "Jio India West"},
				new() {Name = "korea", DisplayName = "Korea"},
				new() {Name = "koreacentral", DisplayName = "Korea Central"},
				new() {Name = "koreasouth", DisplayName = "Korea South"},
				new() {Name = "northcentralus", DisplayName = "North Central US"},
				new() {Name = "northeurope", DisplayName = "North Europe"},
				new() {Name = "norway", DisplayName = "Norway"},
				new() {Name = "norwayeast", DisplayName = "Norway East"},
				new() {Name = "norwaywest", DisplayName = "Norway West"},
				new() {Name = "qatarcentral", DisplayName = "Qatar Central"},
				new() {Name = "singapore", DisplayName = "Singapore"},
				new() {Name = "southafrica", DisplayName = "South Africa"},
				new() {Name = "southafricanorth", DisplayName = "South Africa North"},
				new() {Name = "southafricawest", DisplayName = "South Africa West"},
				new() {Name = "southcentralus", DisplayName = "South Central US"},
				new() {Name = "southcentralusstg", DisplayName = "South Central US STG"},
				new() {Name = "southeastasia", DisplayName = "Southeast Asia"},
				new() {Name = "southindia", DisplayName = "South India"},
				new() {Name = "swedencentral", DisplayName = "Sweden Central"},
				new() {Name = "switzerland", DisplayName = "Switzerland"},
				new() {Name = "switzerlandnorth", DisplayName = "Switzerland North"},
				new() {Name = "switzerlandwest", DisplayName = "Switzerland West"},
				new() {Name = "uae", DisplayName = "United Arab Emirates"},
				new() {Name = "uaecentral", DisplayName = "UAE Central"},
				new() {Name = "uaenorth", DisplayName = "UAE North"},
				new() {Name = "uk", DisplayName = "United Kingdom"},
				new() {Name = "uksouth", DisplayName = "UK South"},
				new() {Name = "ukwest", DisplayName = "UK West"},
				new() {Name = "unitedstates", DisplayName = "United States"},
				new() {Name = "unitedstateseuap", DisplayName = "United States EUAP"},
				new() {Name = "westcentralus", DisplayName = "West Central US"},
				new() {Name = "westeurope", DisplayName = "West Europe"},
				new() {Name = "westindia", DisplayName = "West India"},
				new() {Name = "westus", DisplayName = "West US"},
				new() {Name = "westus2", DisplayName = "West US 2"},
				new() {Name = "westus3", DisplayName = "West US 3"},
				new() {Name = "centralusstage", DisplayName = "Central US (Stage)"},
				new() {Name = "eastasiastage", DisplayName = "East Asia (Stage)"},
				new() {Name = "eastus2stage", DisplayName = "East US 2 (Stage)"},
				new() {Name = "eastusstage", DisplayName = "East US (Stage)"},
				new() {Name = "northcentralusstage", DisplayName = "North Central US (Stage)"},
				new() {Name = "southcentralusstage", DisplayName = "South Central US (Stage)"},
				new() {Name = "southeastasiastage", DisplayName = "Southeast Asia (Stage)"},
				new() {Name = "westus2stage", DisplayName = "West US 2 (Stage)"},
				new() {Name = "westusstage", DisplayName = "West US (Stage)"},
			};

			return regions;
		}
	}
}
