using System;
namespace Thermo.Services;

public static class CalculationService
{
    public static double KurulukDerecesi(double ozellikBuhar, double ozellikSivi)
    {
        var x = ozellikBuhar/(ozellikSivi+ozellikBuhar);
        return x;
    }

    public static double IdealGazBasinc(double hacim, double kutle, double gazSabiti, double sicaklik)
    {
        var basinc = (kutle * gazSabiti * sicaklik) / hacim;
        return basinc;
    }
    public static double IdealGazHacim(double basinc, double kutle, double gazSabiti, double sicaklik)
    {
        var hacim = (kutle * gazSabiti * sicaklik) / basinc;
        return hacim;
    }
    public static double IdealGazKutle(double hacim, double basinc, double gazSabiti, double sicaklik)
    {
        var kutle = (basinc*hacim)/(gazSabiti*sicaklik);
        return kutle;
    }
    public static double IdealGazSabit(double hacim, double basinc, double kutle, double sicaklik)
    {
        var sabit = (basinc*hacim)/(kutle*sicaklik);
        return sabit;
    }
    public static double IdealGazSicaklik(double hacim, double basinc, double kutle, double gazSabiti)
    {
        var sicaklik = (basinc*hacim)/(kutle*gazSabiti);
        return sicaklik;
    }

    public static double IndirgenmisBasinc(double basinc, double basincKritik)
    {
        var indirgenmis = basinc / basincKritik;
        return indirgenmis;
    }
    public static double IndirgenmisSicaklik(double sicaklik, double sicaklikKritik)
    {
        var indirgenmis = sicaklik / sicaklikKritik;
        return indirgenmis;
    }

    public static double BuharlasmaEntalpisi(double entalpiBuhar, double entalpiSivi)
    {
        var buharlasma = entalpiBuhar - entalpiSivi;
        return buharlasma;
    }

    public static double BuharlasmaIcEnerji(double icEnerjiBuhar, double icEnerjiSivi)
    {
        var buharlasma = icEnerjiBuhar - icEnerjiSivi;
        return buharlasma;
    }

    public static double BuharlasmaOzgulHacim(double ozgulHacimBuhar, double ozgulHacimSivi)
    {
        var buharlasma= ozgulHacimBuhar - ozgulHacimSivi;
        return buharlasma;
    }

    public static double SikistirilabilmeCarpani(double basinc, double ozgulHacim, double gazSabiti, double sicaklik,
        double ozgulHacimGercek, double ozgulHacimMukemmel)
    {
        var z = (basinc*ozgulHacim)/(gazSabiti*sicaklik);
        ozgulHacimMukemmel = (gazSabiti * sicaklik) / basinc;
        return z;
    }

    public static double AdyabatikUs(double sabitHacimOzgulIsi, double sabitBasincOzgulIsi)
    {
        var k = sabitBasincOzgulIsi / sabitHacimOzgulIsi;
        return k;
    }
    public static double SabitBasincOzgulIsi(double sabitHacimOzgulIsi, double sabitBasincOzgulIsi, double gazSabiti)
    {
        sabitBasincOzgulIsi = sabitHacimOzgulIsi + gazSabiti;
        return sabitBasincOzgulIsi;
    }

    public static double SabitHacimSinirIsi(double kutle, double sabitHacimOzgulIsi, double sicaklik1, double sicaklik2)
    {
        var q=kutle*sabitHacimOzgulIsi*(sicaklik2 - sicaklik1);
        return q;
    }
    public static double SabitBasincSinirIsi(double kutle, double sabitBasincOzgulIsi, double sicaklik1, double sicaklik2)
    {
        var q=kutle*sabitBasincOzgulIsi*(sicaklik2 - sicaklik1);
        return q;
    }

    public static double IzotermalHalDegisimi(double basinc, double hacim1, double hacim2, double kutle, double sicaklik,
        double gazSabiti)
    {
        var c = basinc * hacim1;
        var w = c * Math.Log(hacim2 / hacim1);
        return w;
    }

    public static double AdyabatikHalDegisimi(double k, double basinc1, double basinc2)
    {
        var c = Math.Pow((basinc1 * basinc2), k);
        return c;
    }
    public static double PolitropikHalDegisimi(double n, double basinc1, double basinc2)
    {
        var c = Math.Pow((basinc1 * basinc2), n);
        return c;
    }
}