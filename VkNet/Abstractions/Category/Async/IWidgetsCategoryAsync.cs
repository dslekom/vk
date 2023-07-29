﻿using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Abstractions;

/// <summary>
/// Методы для работы с виджетами на внешних сайтах.
/// </summary>
public interface IWidgetsCategoryAsync
{
	/// <summary>
	/// Получает список комментариев к странице, оставленных через Виджет комментариев.
	/// </summary>
	/// <param name="getCommentsParams">
	/// Входные параметры запроса.
	/// </param>
	/// <param name="token">Токен отмены операции</param>
	/// <returns>
	/// В случае успеха возвращает объект со следующими полями:
	/// count — общее количество комментариев первого уровня к странице (без учета
	/// ограничений из входного параметра
	/// count).
	/// posts — список комментариев первого уровня. Каждый элемент списка имеет
	/// структуру, схожую с объектами post из
	/// результатов метода wall.get. Помимо этого:
	/// В случае, если среди необходимых полей было указано replies, в поле
	/// comments.replies будет содержаться список
	/// комментариев второго уровня. Каждый элемент этого списка имеет структуру,
	/// схожую с объектами comment из результатов
	/// метода wall.getComments.
	/// В случае, если были указаны любые другие необходимые поля анкет, в каждом
	/// элементе post и comment будет поле user,
	/// содержащее соответствующую информацию об авторе комментария.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/widgets.getComments
	/// </remarks>
	Task<VkCollection<Comment>> GetCommentsAsync(GetCommentsParams getCommentsParams,
												CancellationToken token = default);

	/// <summary>
	/// Получает список страниц приложения/сайта, на которых установлен Виджет
	/// комментариев или «Мне нравится».
	/// </summary>
	/// <param name="widgetApiId">
	/// Идентификатор приложения/сайта, с которым инициализируются виджеты. целое число
	/// </param>
	/// <param name="order">
	/// Тип сортировки страниц. Возможные значения: date, comments, likes,
	/// friend_likes. строка, по умолчанию friend_likes
	/// </param>
	/// <param name="period">
	/// Период выборки. Возможные значения: day, week, month, alltime. строка, по
	/// умолчанию week
	/// </param>
	/// <param name="offset">
	/// Смещение необходимое для выборки определенного подмножества комментариев. По
	/// умолчанию 0. положительное число, по
	/// умолчанию 0
	/// </param>
	/// <param name="count">
	/// Количество возвращаемых записей. положительное число, по умолчанию 10,
	/// минимальное значение 10, максимальное
	/// значение 200
	/// </param>
	/// <param name="token">Токен отмены операции</param>
	/// <returns>
	/// В случае успеха возвращает объект со следующими полями:
	/// count — общее количество страниц (без учета ограничений входного параметра
	/// count)
	/// pages — список объектов-страниц
	/// Каждый объект, описывающий страницу, имеет следующие поля:
	/// id — идентификатор страницы в системе;
	/// title — заголовок страницы (берется из мета-тегов на странице или задается
	/// параметром pageTitle при инициализации)
	/// description — краткое описание страницы (берется из мета-тегов на странице или
	/// задается параметром pageDescription
	/// при инициализации);
	/// photo — объект, содержащий фотографию-миниатюру страницы (берется из мета-тегов
	/// на странице или задается параметром
	/// pageImage при инициализации)
	/// url — абсолютный адрес страницы;
	/// likes — объект, содержащий поле count — количество отметок «Мне нравится» к
	/// странице. Для получения списка
	/// пользователей, отметивших страницу можно использовать метод likes.getList с
	/// параметром type равным site_page;
	/// comments — объект, содержащий поле count — количество комментариев к странице
	/// внутри виджета. Для получения списка
	/// комментариев можно использовать метод widgets.getComments;
	/// date — дата первого обращения к виджетам на странице
	/// page_id — внутренний идентификатор страницы в приложении/на сайте (в случае,
	/// если при инициализации виджетов
	/// использовался параметр page_id);
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/widgets.getPages
	/// </remarks>
	Task<VkCollection<WidgetPage>> GetPagesAsync(long? widgetApiId = null,
												string order = null,
												string period = null,
												ulong? offset = null,
												ulong? count = null,
												CancellationToken token = default);
}