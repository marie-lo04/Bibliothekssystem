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
        '                                "978-0-13-110362-7; Programmieren mit VB.NET; Schneider; verfügbar |" &
        '                               "978-3-540-69006-6; Grundlagen der Softwaretechnik; Meier; ausgeliehen |" &
        '                              "978-3-642-05445-3; Datenstrukturen und Algorithmen; Klein; verfügbar"

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
            '   Console.WriteLine("Bücher im System:")
            '  Console.WriteLine("-----------------")
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
            '   Console.WriteLine("Das Programm wird jetzt beendet.")

            'Else
            ' Rückmeldung bei falscher Taste
            '   Console.WriteLine("Ungültige Eingabe! Bitte wählen Sie 1, 2, 3 oder x.")
            'End If

            ' Verhindert, dass das Menü sofort neu lädt, damit man das Ergebnis lesen kann
            'If auswahl <> "x" Then
            '   Console.WriteLine(vbCrLf & "Drücken Sie eine Taste, um zum Menü zurückzukehren...")
            '  Console.ReadKey()
            'End If

            If auswahl <> "x" Then
                Console.WriteLine(vbCrLf & "Weiter mit beliebiger Taste...")
                Console.ReadKey()
            End If

        Loop While auswahl <> "x" ' Beendet die Schleife, wenn 'x' eingegeben wurde
    End Sub

    Sub BenutzerAnlegen()
        Console.WriteLine("Funktion: Benutzer anlegen (noch nicht programmiert)")
    End Sub

    Sub AlleBuecherAnzeigen()
        Console.WriteLine("Liste aller Bücher:")
        ' Hier gehen wir später mit einer For-Schleife durch das Array buecherListe
        For i As Integer = 0 To buchAnzahl - 1
            Console.WriteLine(buecherListe(i).ISBN & " - " & buecherListe(i).Titel)
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
        Console.WriteLine("Funktion: Buch ausleihen (Logik folgt)")
    End Sub

    Sub BuchZurueckgeben()
        Console.WriteLine("Funktion: Buch zurückgeben (Logik folgt)")
    End Sub

    ''' <summary>
    ''' Liest die Daten aus den CSV-Dateien in die Arrays
    ''' </summary

    Sub DatenLaden()

        ' Prüfen, ob die Bücher-Datei existiert
        If File.Exists("library_books.csv") Then
            Dim bZeilen = File.ReadAllLines("library_books.csv")
            For Each zeile In bZeilen
                Dim spalten = zeile.Split(","c)
                buecherListe(buchAnzahl).ISBN = spalten(0).Trim()
                buecherListe(buchAnzahl).Titel = spalten(1).Trim()
                buecherListe(buchAnzahl).Autor = spalten(2).Trim()
                buecherListe(buchAnzahl).Status = spalten(3).Trim()
                buchAnzahl += 1

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
                If benutzerAnzahl < 999 Then
                    Dim spalten = zeile.Split(","c)
                    benutzerListe(benutzerAnzahl).ID = spalten(0).Trim()
                    benutzerListe(benutzerAnzahl).Name = spalten(1).Trim()
                    benutzerAnzahl += 1
                End If
            Next
            Console.WriteLine("Benutzer erfolgreich geladen.")

        Else
            Console.WriteLine("Hinweis: Datei library_users.csv wurde nicht gefunden.")
        End If
    End Sub
End Module