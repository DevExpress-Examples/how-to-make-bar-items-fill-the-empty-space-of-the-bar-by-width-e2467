﻿Imports System.ComponentModel
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Styles

Namespace SpringStyleItem
	Public Class MyBarAndDockingController
		Inherits BarAndDockingController

'INSTANT VB NOTE: The field springStyleItems was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private springStyleItems_Renamed As BarItemCollection

		Public Sub New(ByVal container As IContainer)
			MyBase.New(container)
			Init()
		End Sub
		Public Sub New()
			MyBase.New()
			Init()
		End Sub

		Private Sub Init()
			springStyleItems_Renamed = New BarItemCollection(Me)
		End Sub

		Protected Friend Shadows Sub OnChanged()
			MyBase.OnChanged()
		End Sub

		Public Sub AddBarControlInfo()
			For Each paintStyle As BarManagerPaintStyle In Me.PaintStyles
				Dim info As BarControlInfo = paintStyle.BarInfoCollection("DockedBarControl")
				If info IsNot Nothing Then
					Dim infos As New BarControlInfoCollection(paintStyle)
					For i As Integer = 0 To paintStyle.BarInfoCollection.Count - 1
						Dim barInfo As BarControlInfo = paintStyle.BarInfoCollection(i)
						If barInfo.Name <> "DockedBarControl" Then
							infos.Add(New BarControlInfo(barInfo.Name, barInfo.ItemType, barInfo.ViewInfoType, barInfo.Painter))
						Else
							infos.Add(New BarControlInfo(barInfo.Name, barInfo.ItemType, GetType(MyDockedBarControlViewInfo), barInfo.Painter))
						End If
					Next i

					paintStyle.BarInfoCollection.Clear()
					For i As Integer = 0 To infos.Count - 1
						paintStyle.BarInfoCollection.Add(New BarControlInfo(infos(i).Name, infos(i).ItemType, infos(i).ViewInfoType, infos(i).Painter))
					Next i
				End If
			Next paintStyle
		End Sub

		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
		Public ReadOnly Property SpringStyleItems() As BarItemCollection
			Get
				Return springStyleItems_Renamed
			End Get
		End Property
	End Class
End Namespace
