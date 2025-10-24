USE [TaskHubDb];
GO

SET NOCOUNT ON;

DECLARE @UserAliceId INT;
DECLARE @UserBobId INT;
DECLARE @WorkspaceAliceId INT;
DECLARE @WorkspaceBobId INT;

INSERT INTO [dbo].[Users] ([Username], [Password], [Email], [AccountCreated])
VALUES (CONVERT(TEXT, 'alice'), CONVERT(TEXT, 'Password123!'), CONVERT(TEXT, 'alice@example.com'), SYSUTCDATETIME());
SET @UserAliceId = SCOPE_IDENTITY();

INSERT INTO [dbo].[Users] ([Username], [Password], [Email], [AccountCreated])
VALUES (CONVERT(TEXT, 'bob'), CONVERT(TEXT, 'SecurePass456!'), CONVERT(TEXT, 'bob@example.com'), SYSUTCDATETIME());
SET @UserBobId = SCOPE_IDENTITY();

INSERT INTO [dbo].[Workspaces] ([OwnerID], [GroupID], [Name], [Description])
VALUES (@UserAliceId, NULL, CONVERT(TEXT, 'Alice Workspace'), CONVERT(TEXT, 'Planning board for Alice projects.'));
SET @WorkspaceAliceId = SCOPE_IDENTITY();

INSERT INTO [dbo].[Workspaces] ([OwnerID], [GroupID], [Name], [Description])
VALUES (@UserBobId, NULL, CONVERT(TEXT, 'Bob Workspace'), CONVERT(TEXT, 'Workspace tracking Bob tasks.'));
SET @WorkspaceBobId = SCOPE_IDENTITY();

INSERT INTO [dbo].[Tasks] ([GroupID], [WorkspaceID], [Assignee], [TaskStatus], [TaskContents], [TaskName])
VALUES (NULL, @WorkspaceAliceId, CONVERT(TEXT, 'alice'), 0, CONVERT(TEXT, 'Outline project goal and deliverables.'), CONVERT(TEXT, 'Define Milestones'));

INSERT INTO [dbo].[Tasks] ([GroupID], [WorkspaceID], [Assignee], [TaskStatus], [TaskContents], [TaskName])
VALUES (NULL, @WorkspaceAliceId, CONVERT(TEXT, 'alice'), 1, CONVERT(TEXT, 'Prepare status report for stakeholders.'), CONVERT(TEXT, 'Draft Status Report'));

INSERT INTO [dbo].[Tasks] ([GroupID], [WorkspaceID], [Assignee], [TaskStatus], [TaskContents], [TaskName])
VALUES (NULL, @WorkspaceBobId, CONVERT(TEXT, 'bob'), 0, CONVERT(TEXT, 'Review documentstion and find gaps.'), CONVERT(TEXT, 'Documentation Review'));

INSERT INTO [dbo].[Tasks] ([GroupID], [WorkspaceID], [Assignee], [TaskStatus], [TaskContents], [TaskName])
VALUES (NULL, @WorkspaceBobId, CONVERT(TEXT, 'bob'), 2, CONVERT(TEXT, 'Coordinate with QA for testing.'), CONVERT(TEXT, 'Plan Testing'));

PRINT 'Test data setup successfully.';
