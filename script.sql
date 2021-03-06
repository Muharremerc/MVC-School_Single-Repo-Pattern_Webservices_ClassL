USE [MVC_School]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 10/04/2018 23:48:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Surname] [nvarchar](50) NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lesson]    Script Date: 10/04/2018 23:48:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lesson](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LessonName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Lesson] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Class]    Script Date: 10/04/2018 23:48:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 10/04/2018 23:48:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Surname] [nvarchar](50) NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeacherLesson]    Script Date: 10/04/2018 23:48:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeacherLesson](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeacherId] [int] NULL,
	[LessonId] [int] NULL,
 CONSTRAINT [PK_TeacherLesson] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeacherClass]    Script Date: 10/04/2018 23:48:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeacherClass](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClassId] [int] NULL,
	[TeacherId] [int] NULL,
 CONSTRAINT [PK_TeacherClass] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentLesson]    Script Date: 10/04/2018 23:48:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentLesson](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LessonId] [int] NULL,
	[StudentId] [int] NULL,
 CONSTRAINT [PK_StudentLesson] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentClass]    Script Date: 10/04/2018 23:48:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentClass](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NULL,
	[ClassId] [int] NULL,
 CONSTRAINT [PK_ClassPeople] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_StudentClass_Class]    Script Date: 10/04/2018 23:48:45 ******/
ALTER TABLE [dbo].[StudentClass]  WITH CHECK ADD  CONSTRAINT [FK_StudentClass_Class] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Class] ([Id])
GO
ALTER TABLE [dbo].[StudentClass] CHECK CONSTRAINT [FK_StudentClass_Class]
GO
/****** Object:  ForeignKey [FK_StudentClass_Student]    Script Date: 10/04/2018 23:48:45 ******/
ALTER TABLE [dbo].[StudentClass]  WITH CHECK ADD  CONSTRAINT [FK_StudentClass_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[StudentClass] CHECK CONSTRAINT [FK_StudentClass_Student]
GO
/****** Object:  ForeignKey [FK_StudentLesson_Lesson]    Script Date: 10/04/2018 23:48:45 ******/
ALTER TABLE [dbo].[StudentLesson]  WITH CHECK ADD  CONSTRAINT [FK_StudentLesson_Lesson] FOREIGN KEY([LessonId])
REFERENCES [dbo].[Lesson] ([Id])
GO
ALTER TABLE [dbo].[StudentLesson] CHECK CONSTRAINT [FK_StudentLesson_Lesson]
GO
/****** Object:  ForeignKey [FK_StudentLesson_Student]    Script Date: 10/04/2018 23:48:45 ******/
ALTER TABLE [dbo].[StudentLesson]  WITH CHECK ADD  CONSTRAINT [FK_StudentLesson_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[StudentLesson] CHECK CONSTRAINT [FK_StudentLesson_Student]
GO
/****** Object:  ForeignKey [FK_TeacherClass_Class]    Script Date: 10/04/2018 23:48:45 ******/
ALTER TABLE [dbo].[TeacherClass]  WITH CHECK ADD  CONSTRAINT [FK_TeacherClass_Class] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Class] ([Id])
GO
ALTER TABLE [dbo].[TeacherClass] CHECK CONSTRAINT [FK_TeacherClass_Class]
GO
/****** Object:  ForeignKey [FK_TeacherClass_Teacher]    Script Date: 10/04/2018 23:48:45 ******/
ALTER TABLE [dbo].[TeacherClass]  WITH CHECK ADD  CONSTRAINT [FK_TeacherClass_Teacher] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teacher] ([Id])
GO
ALTER TABLE [dbo].[TeacherClass] CHECK CONSTRAINT [FK_TeacherClass_Teacher]
GO
/****** Object:  ForeignKey [FK_TeacherLesson_Lesson]    Script Date: 10/04/2018 23:48:45 ******/
ALTER TABLE [dbo].[TeacherLesson]  WITH CHECK ADD  CONSTRAINT [FK_TeacherLesson_Lesson] FOREIGN KEY([LessonId])
REFERENCES [dbo].[Lesson] ([Id])
GO
ALTER TABLE [dbo].[TeacherLesson] CHECK CONSTRAINT [FK_TeacherLesson_Lesson]
GO
/****** Object:  ForeignKey [FK_TeacherLesson_Teacher]    Script Date: 10/04/2018 23:48:45 ******/
ALTER TABLE [dbo].[TeacherLesson]  WITH CHECK ADD  CONSTRAINT [FK_TeacherLesson_Teacher] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teacher] ([Id])
GO
ALTER TABLE [dbo].[TeacherLesson] CHECK CONSTRAINT [FK_TeacherLesson_Teacher]
GO
