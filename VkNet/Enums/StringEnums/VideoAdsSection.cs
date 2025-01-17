﻿using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// TODO: Undocumented enum, which is a part of sections field in VideoAds
/// <remarks>
/// This enum must be pointing to the positions at which ads can be played
/// </remarks>
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum VideoAdsSection
{
	/// <summary>
	/// TODO: Undocumented
	/// <remarks>
	/// This is probably in the start of the video
	/// </remarks>
	/// </summary>
	Preroll,

	/// <summary>
	/// TODO: Undocumented
	/// <remarks>
	/// This is probably in the middle of the video
	/// </remarks>
	/// </summary>
	Midroll,

	/// <summary>
	/// TODO: Undocumented
	/// <remarks>
	/// This is probably in the end of the video
	/// </remarks>
	/// </summary>
	Postroll
}