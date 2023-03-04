using System;
using Newtonsoft.Json;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model.GroupUpdate;

/// <summary>
/// Новая запись на стене (<c>WallPost</c>, <c>WallRepost</c>)
/// (<c>Post</c> с дополнительными полями)
/// </summary>
[Serializable]
public class WallPost : Post, IGroupUpdate
{
	/// <summary>
	/// <c>Id</c> отложенной записи
	/// </summary>
	[JsonProperty("postponed_id")]
	public long? PostponedId { get; set; }

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	public new static WallPost FromJson(VkResponse response) => new()
	{
		Id = response[key: "id"],
		OwnerId = response[key: "owner_id"],
		FromId = response[key: "from_id"],
		Date = response[key: "date"],
		Text = response[key: "text"],
		ReplyOwnerId = response[key: "reply_owner_id"],
		ReplyPostId = response[key: "reply_post_id"],
		FriendsOnly = response[key: "friends_only"],
		Comments = !response.ContainsKey("comments") ? null : JsonConvert.DeserializeObject<Comments>(response[key: "comments"].ToString()),
		Likes = !response.ContainsKey("likes") ? null : JsonConvert.DeserializeObject<Likes>(response[key: "likes"].ToString()),
		Reposts = !response.ContainsKey("reposts") ? null : JsonConvert.DeserializeObject<Reposts>(response[key: "reposts"].ToString()),
		PostType = response[key: "post_type"],
		PostSource = !response.ContainsKey("post_source") ? null : JsonConvert.DeserializeObject<PostSource>(response[key: "post_source"].ToString()),
		Attachments = response[key: "attachments"]
			.ToReadOnlyCollectionOf<Attachment>(selector: x => x),
		Geo = !response.ContainsKey("geo") ? null : JsonConvert.DeserializeObject<Geo>(response[key: "geo"].ToString()),
		SignerId = response[key: "signer_id"],
		CopyPostDate = response[key: "copy_post_date"],
		CopyPostType = response[key: "copy_post_type"],
		CopyOwnerId = response[key: "copy_owner_id"],
		CopyPostId = response[key: "copy_post_id"],
		CopyText = response[key: "copy_text"],
		CopyHistory = response[key: "copy_history"]
			.ToReadOnlyCollectionOf<Post>(selector: x => x),
		IsPinned = response[key: "is_pinned"],
		CreatedBy = response[key: "created_by"],
		CopyCommenterId = response[key: "copy_commenter_id"],
		CopyCommentId = response[key: "copy_comment_id"],
		CanDelete = response[key: "can_delete"],
		CanEdit = response[key: "can_edit"],
		CanPin = response[key: "can_pin"],
		Views = !response.ContainsKey("views") ? null : JsonConvert.DeserializeObject<PostView>(response[key: "views"].ToString()),
		MarkedAsAds = response[key: "marked_as_ads"],
		AccessKey = response[key: "access_key"],
		PostponedId = response["postponed_id"],
		Donut = !response.ContainsKey("donut") ? null : JsonConvert.DeserializeObject<PostDonut>(response[key: "donut"].ToString()),
	};

	/// <summary>
	/// Преобразование класса <see cref="WallPost" /> в <see cref="VkParameters" />
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> Результат преобразования в <see cref="WallPost" /> </returns>
	public static implicit operator WallPost(VkResponse response)
	{
		if (response == null)
		{
			return null;
		}

		return response.HasToken()
			? FromJson(response)
			: null;
	}
}