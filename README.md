# TestSearchAutoComplete
Проект демонстрирует реализацию автодополнения поиска с использованием полнотекстового поиска PostgreSQL.
<img width="1068" alt="Screenshot 2024-11-16 at 02 08 58" src="https://github.com/user-attachments/assets/b5e63d97-7c63-48ec-bd20-e9df64a1258f">
## Технологии
- ASP.NET Core
- PosgreSQL
- Entity Framework Core
- HTML/CSS/JavaScript
## Структура проекта
- `Controllers/NotesController.cs` - API контроллер для работы с заметками
- `Models/Note.cs` - Модель данных заметки
- `migrations.sql` - SQL-скрипт для создания базы данных и триггеров
- `wwwroot/` - Статические файлы веб-интерфейса
# API
### POST /api/notes
Создает новую заметку
### GET /api/notes/search?text={query}
Выполняет поиск заметок по тексту
## Полнотекстовый поиск
- Использует `tsvector` в PostgreSQL для эффективного полнотекстового поиска
- Различные веса для названия (A) и содержимого (B) заметки
- Автоматическое обновление поискового вектора через триггеры
- Дебаунсинг поисковых запросов на фронтенде
<img width="1068" alt="Screenshot 2024-11-16 at 02 09 08" src="https://github.com/user-attachments/assets/ce1b6315-6d65-4379-b43a-1a5286aaa9a5">
