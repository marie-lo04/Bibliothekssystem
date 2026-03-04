Imports System.IO

''' <summary>
''' Hauptmodul für das Bibliothekssystem - Projekt Teil I
''' </summary>
Module Module1

    ' Strukturen bündeln zusammengehörige Daten (z.B. alle Infos zu einem Buch)
    Structure Buch
        Dim ISBN As String
        Dim Titel As String
        Dim Autor As String
        Dim Status As String
    End Structure

    Structure Benutzer
        Dim ID As String
        Dim Name As String
    End Structure

    ' Globaler Speicher Limit 999
    Dim buecherListe(999) As Buch ' Platz für Bücher
    Dim benutzerListe(999) As Benutzer ' Limit von 999 Benutzern 
    Dim buchAnzahl As Integer = 0
    Dim benutzerAnzahl As Integer = 0

    Sub Main()
        'Teil 1:
        'Testdaten als lange Zeichenkette (String), wie im PDF gefordert
        'Dim libraryTestData As String = "978-3-16-148410-0; Einführung in die Informatik; Müller; verfügbar|" &
        '                                "978-0-13-110362-7; Programmieren mit VB.NET; Schneider; verfügbar |" &
        '                               "978-3-540-69006-6; Grundlagen der Softwaretechnik; Meier; ausgeliehen |" &
        '                              "978-3-642-05445-3; Datenstrukturen und Algorithmen; Klein; verfügbar"

        'Dim usrTestData As String = "U001; Max Mustermann |U002; Erika Musterfrau|U003; Hans Meier |U004; Laura Schmidt"


        DatenLaden()
        Dim auswahl As String = ""

        ' Die Schleife sorgt dafür, dass das Menü nach jeder Aktion neu erscheint
        Do
            Console.Clear() ' Macht den Bildschirm für das Menü sauber
            Console.WriteLine("--- DHBW Bibliothekssystem ---")
            Console.WriteLine("1: Neuen Benutzer anlegen")
            Console.WriteLine("2: Alle Bücher anzeigen")
            Console.WriteLine("3: Alle Benutzer anzeigen")
            Console.WriteLine("4: Buch ausleihen")
            Console.WriteLine("5: Buch zurückgeben")
            Console.WriteLine("x: Programm beenden")
            Console.Write("Auswahl: ")

            auswahl = Console.ReadLine().ToLower()

            'Teil 1:
            'Prüfung der Eingabe mit If-ElseIf
            'If auswahl = "1" Then
            ' Platzhalter für die spätere Logik in Teil II
            'Console.WriteLine("Funktion: Neuen Benutzer anlegen ausgewählt.")

            'ElseIf auswahl = "2" Then
            ' Zeigt die Bücherliste an
            '   Console.WriteLine("Bücher im System:")
            '  Console.WriteLine("-----------------")
            ' Teilt den langen String beim Trennzeichen '|' in einzelne Zeilen
            ' Dim buecher() As String = libraryTestData.Split("|"c)
            'For Each b In buecher
            'Console.WriteLine(b.Trim()) ' Trim entfernt Leerzeichen am Rand
            'Next

            If auswahl = "1" Then
                BenutzerAnlegen()
            ElseIf auswahl = "2" Then
                AlleBuecherAnzeigen()
            ElseIf auswahl = "3" Then
                AlleBenutzerAnzeigen()
            ElseIf auswahl = "4" Then
                BuchAusleihen()
            ElseIf auswahl = "5" Then
                BuchZurueckgeben()
            End If

            'Teil 1:
            'ElseIf auswahl = "3" Then
            ' Zeigt die Benutzerliste an
            'Console.WriteLine("Registrierte Benutzer:")
            'Console.WriteLine("----------------------")
            ' Teilt den String beim Trennzeichen '|'
            'Dim nutzer() As String = usrTestData.Split("|"c)
            'For Each n In nutzer
            'Console.WriteLine(n.Trim())
            'Next

            'ElseIf auswahl = "x" Then
            '   Console.WriteLine("Das Programm wird jetzt beendet.")

            'Else
            ' Rückmeldung bei falscher Taste
            '   Console.WriteLine("Ungültige Eingabe! Bitte wählen Sie 1, 2, 3 oder x.")
            'End If

            ' Verhindert, dass das Menü sofort neu lädt, damit man das Ergebnis lesen kann
            'If auswahl <> "x" Then
            '   Console.WriteLine(vbCrLf & "Drücken Sie eine Taste, um zum Menü zurückzukehren...")
            '  Console.ReadKey()
            'End If

            If auswahl <> "x" Then
                Console.WriteLine(vbCrLf & "Weiter mit beliebiger Taste...")
                Console.ReadKey()
            End If

        Loop While auswahl <> "x" ' Beendet die Schleife, wenn 'x' eingegeben wurde
    End Sub

    Sub BenutzerAnlegen()
        Console.WriteLine()
        Console.WriteLine("--- Neuen Benutzer registrieren ---")

        ' Prüfung: Ist noch Platz im Array? (Vorgabe max. 999)
        If benutzerAnzahl < 999 Then
            Console.Write("Bitte eine neue User-ID eingeben (z.B. U005): ")
            Dim neueID As String = Console.ReadLine()

            Console.Write("Bitte den Namen des Benutzers eingeben: ")
            Dim neuerName As String = Console.ReadLine()

            ' Speichern im array an der nächsten freien Stelle
            benutzerListe(benutzerAnzahl).ID = neueID
            benutzerListe(benutzerAnzahl).Name = neuerName

            ' Zähler um 1 erhöhen, damit der nächste Benutzer dahinter landet
            benutzerAnzahl += 1
            Console.WriteLine("Erfolg: Benutzer wurde gespeichert.")
        Else
            Console.WriteLine("Fehler: Das Limit von 999 Benutzern ist erreicht!")
        End If
    End Sub

    Sub AlleBuecherAnzeigen()
        Console.WriteLine("Liste aller Bücher:")
        ' Hier gehen wir später mit einer For-Schleife durch das Array buecherListe
        For i As Integer = 0 To buchAnzahl - 1
            Console.WriteLine(buecherListe(i).ISBN & " - " & buecherListe(i).Titel & " [" & buecherListe(i).Status & "]")
        Next
    End Sub

    Sub AlleBenutzerAnzeigen()
        Console.WriteLine("Liste aller Benutzer:")
        ' Hier gehen wir durch das Array benutzerListe
        For i As Integer = 0 To benutzerAnzahl - 1
            Console.WriteLine(benutzerListe(i).ID & ": " & benutzerListe(i).Name)
        Next
    End Sub

    Sub BuchAusleihen()
        Console.WriteLine()
        Console.Write("Geben Sie die ISBN des Buches ein: ")
        Dim gesuchteISBN As String = Console.ReadLine().Trim()
        Dim gefunden As Boolean = False

        ' Wir suchen in der buecherListe nach der passenden ISBN
        For i As Integer = 0 To buchAnzahl - 1
            If buecherListe(i).ISBN.Trim() = gesuchteISBN Then
                gefunden = True
                ' Prüfen, ob das Buch überhaupt da ist
                If buecherListe(i).Status.Trim().ToLower() = "available" Then
                    buecherListe(i).Status = "ausgeliehen"
                    Console.WriteLine("Erfolg: '" & buecherListe(i).Titel & "' ist nun ausgeliehen.")
                Else
                    Console.WriteLine("Hinweis: Dieses Buch ist bereits vergeben (Status: " & buecherListe(i).Status & ").")
                End If
                Exit For ' Suche abbrechen, wenn gefunden
            End If
        Next

        If Not gefunden Then
            Console.WriteLine("Fehler: Buch mit dieser ISBN nicht gefunden.")
        End If
    End Sub


    Sub BuchZurueckgeben()
        Console.WriteLine()
        Console.Write("Geben Sie die ISBN für die Rückgabe ein: ")
        Dim gesuchteISBN As String = Console.ReadLine().Trim()

        For i As Integer = 0 To buchAnzahl - 1
            If buecherListe(i).ISBN.Trim() = gesuchteISBN Then
                buecherListe(i).Status = "available"
                Console.WriteLine("Erfolg: '" & buecherListe(i).Titel & "' ist wieder verfügbar.")
                Return ' Wir können hier direkt aufhören
            End If
        Next

        Console.WriteLine("Fehler: Diese ISBN existiert nicht im System.")
    End Sub

    ''' <summary>
    ''' Liest die Daten aus den CSV-Dateien in die Arrays
    ''' </summary

    Sub DatenLaden()

        ' Prüfen, ob die Bücher-Datei existiert
        If File.Exists("library_books.csv") Then
            Dim bZeilen = File.ReadAllLines("library_books.csv")
            For Each zeile In bZeilen
                If Not String.IsNullOrWhiteSpace(zeile) Then
                    Dim spalten = zeile.Split(New Char() {","c, ";"c})
                    If spalten.Length >= 4 Then
                        buecherListe(buchAnzahl).ISBN = spalten(0).Trim()
                        buecherListe(buchAnzahl).Titel = spalten(1).Trim()
                        buecherListe(buchAnzahl).Autor = spalten(2).Trim()
                        buecherListe(buchAnzahl).Status = spalten(3).Trim()
                        buchAnzahl += 1
                    End If
                End If

                'TEil 1:
                'For Each zeile In uZeilen
                'Dim spalten = zeile.Split(";"c)
                'benutzerListe(benutzerAnzahl).ID = spalten(0).Trim()
                'benutzerListe(benutzerAnzahl).Name = spalten(1).Trim()
                'benutzerAnzahl += 1
                'Next
            Next
        Else
            Console.WriteLine("Hinweis: Datei library_books.csv wurde nicht gefunden.")
        End If

        ' Prüfen, ob die Benutzer-Datei existiert
        If File.Exists("library_users.csv") Then
            Dim uZeilen = File.ReadAllLines("library_users.csv")
            For Each zeile In uZeilen
                'Teil 1:
                'Dim spalten = zeile.Split(";"c)
                'benutzerListe(benutzerAnzahl).ID = spalten(0).Trim()
                'benutzerListe(benutzerAnzahl).Name = spalten(1).Trim()
                'benutzerAnzahl += 1

                ' Limit von 999 Benutzern prüfen (Vorgabe 2.e)
                If Not String.IsNullOrWhiteSpace(zeile) AndAlso benutzerAnzahl < 999 Then
                    Dim spalten = zeile.Split(New Char() {","c, ";"c})
                    If spalten.Length >= 2 Then
                        benutzerListe(benutzerAnzahl).ID = spalten(0).Trim()
                        benutzerListe(benutzerAnzahl).Name = spalten(1).Trim()
                        benutzerAnzahl += 1
                    End If
                End If
            Next
            Console.WriteLine("Benutzer erfolgreich geladen.")
        End If
    End Sub
    Sub DatenSpeichern()
        Try
            Dim bOut As New System.Collections.Generic.List(Of String)
            For i As Integer = 0 To buchAnzahl - 1
                bOut.Add(buecherListe(i).ISBN & "," & buecherListe(i).Titel & "," & buecherListe(i).Autor & "," & buecherListe(i).Status)
            Next
            File.WriteAllLines("library_books.csv", bOut)

            Dim uOut As New System.Collections.Generic.List(Of String)
            For i As Integer = 0 To benutzerAnzahl - 1
                uOut.Add(benutzerListe(i).ID & "," & benutzerListe(i).Name)
            Next
            File.WriteAllLines("library_users.csv", uOut)
            Console.WriteLine("Daten wurden gespeichert.")
        Catch ex As Exception
            Console.WriteLine("Fehler beim Speichern!")
        End Try
    End Sub

End Module