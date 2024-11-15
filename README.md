# TestSearchAutoComplete
Проект демонстрирует реализацию автодополнения поиска с использованием полнотекстового поиска PostgreSQL.
<img width="1068" alt="Screenshot 2024-11-16 at 02 08 58" src="https://github.com/user-attachments/assets/4b0ef6d6-73b4-487a-b118-970bbf87447f">
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
<img width="1068" alt="Screenshot 2024-11-16 at 02 09 08" src="https://github.com/user-attachments/assets/4ff0141d-8d4c-4d14-9e89-900d01e2485b">
