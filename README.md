# Отчет по практической работе №6.2: СОЗДАНИЕ АВТОМАТИЗИРОВАННОГО UNIT-ТЕСТА

## Содержание
1. [Скриншоты](#скриншоты)
2. [Результаты тестирования](#результаты-тестирования)
3. [SQL-скрипт базы данных](#sql-скрипт-базы-данных)
4. [Ссылка на репозиторий](#ссылка-на-репозиторий)

## Скриншоты

### 1. Таблица пользователей в SQL Server
![image](https://github.com/user-attachments/assets/2d488d27-831f-45dc-a2f1-43047dc4f6b6)


### 2. Обозреватель тестов в Visual Studio
![image](https://github.com/user-attachments/assets/d1feba66-54fe-4734-aa97-bdfac39b8c69)


## Результаты тестирования

### Выводы
✅ Все тестовые сценарии отрабатывают корректно  
✅ Система правильно обрабатывает:
   - Валидные и невалидные учетные данные
   - Попытки дублирования пользователей
   - Крайние случаи (пустые строки, пробелы)  
✅ Среднее время выполнения всех тестов - около 2-3 секунд

## SQL-скрипт базы данных

[UploadingU
SE [Футбольный_клуб]
GO
/****** Object:  Index [UQ__Users__536C85E43C1803A2]    Script Date: 30.03.2025 22:13:01 ******/
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [UQ__Users__536C85E43C1803A2]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 30.03.2025 22:13:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 30.03.2025 22:13:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Username], [Password], [Role]) VALUES (3, N'vanek', N'1324', N'Администратор')
INSERT [dbo].[Users] ([Id], [Username], [Password], [Role]) VALUES (4, N'Messi', N'123', N'Игрок')
INSERT [dbo].[Users] ([Id], [Username], [Password], [Role]) VALUES (6, N'ivan_petrov', N'pass123', N'Player')
INSERT [dbo].[Users] ([Id], [Username], [Password], [Role]) VALUES (7, N'alexey_smirnov', N'pass123', N'Player')
INSERT [dbo].[Users] ([Id], [Username], [Password], [Role]) VALUES (8, N'sergey_ivanov', N'pass123', N'Player')
INSERT [dbo].[Users] ([Id], [Username], [Password], [Role]) VALUES (9, N'dmitry_kuznetsov', N'pass123', N'Player')
INSERT [dbo].[Users] ([Id], [Username], [Password], [Role]) VALUES (10, N'nikolay_sidorov', N'pass123', N'Player')
INSERT [dbo].[Users] ([Id], [Username], [Password], [Role]) VALUES (11, N'existing_user', N'Pass123', N'Тренер')
INSERT [dbo].[Users] ([Id], [Username], [Password], [Role]) VALUES (12, N'test_user_1fae4783', N'TestPass123', N'Игрок')
INSERT [dbo].[Users] ([Id], [Username], [Password], [Role]) VALUES (13, N'existing_user_94b9c522', N'Pass123', N'Тренер')
INSERT [dbo].[Users] ([Id], [Username], [Password], [Role]) VALUES (14, N'test_user_cad3c9b6', N'TestPass123', N'Игрок')
INSERT [dbo].[Users] ([Id], [Username], [Password], [Role]) VALUES (15, N'existing_user_c883e67a', N'Pass123', N'Тренер')
INSERT [dbo].[Users] ([Id], [Username], [Password], [Role]) VALUES (16, N'test_user_adce12bb', N'TestPass123', N'Игрок')
INSERT [dbo].[Users] ([Id], [Username], [Password], [Role]) VALUES (17, N'existing_user_03937f4d', N'Pass123', N'Тренер')
INSERT [dbo].[Users] ([Id], [Username], [Password], [Role]) VALUES (18, N'test_user_0fb95607', N'TestPass123', N'Игрок')
INSERT [dbo].[Users] ([Id], [Username], [Password], [Role]) VALUES (19, N'existing_user_8f00b27a', N'Pass123', N'Тренер')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__536C85E43C1803A2]    Script Date: 30.03.2025 22:13:01 ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
 database_script.sql…]()

#P.S - Скрипт Таблицы Users находится в репозитории
