using VkNet.Enums;

namespace VkNet.Abstractions.Core;

/// <summary>
/// Сервис управления языком
/// </summary>
public interface ILanguageService
{
	/// <summary>
	/// Установить язык
	/// </summary>
	/// <param name="language">Язык</param>
	void SetLanguage(Language language);

	/// <summary>
	/// Установить язык
	/// </summary>
	/// <returns>
	/// Язык
	/// </returns>
	Language? GetLanguage();
}