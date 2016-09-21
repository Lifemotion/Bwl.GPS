#ifndef GPS_ML8088_H_
#define GPS_ML8088_H_

void gps_ml8088_init_gprmc_10hz()
{
	uart_disable(1);
	wdt_reset();
	gps_power(0);
	_delay_ms(2000);
	wdt_reset();
	gps_power(1);
	_delay_ms(50);
	gps_reset(0);
	
	_delay_ms(2000);
	uart_init_withdivider_x2(1,16); //16 for 112500 x2 on 16Mhz
	uart_send_string(1,"\r\n$PSTMSETPAR,1102,8*\r\n");_delay_ms(10);	uart_send_string(1,"\r\n$PSTMSAVEPAR*\r\n");_delay_ms(200);
	uart_send_string(1,"\r\n$PSTMSETPAR,1102,8*\r\n");_delay_ms(10);	uart_send_string(1,"\r\n$PSTMSAVEPAR*\r\n");_delay_ms(200);
	uart_send_string(1,"\r\n$PSTMSETPAR,1102,8*\r\n");_delay_ms(10);	uart_send_string(1,"\r\n$PSTMSAVEPAR*\r\n");_delay_ms(200);
	gps_reset(0);
	wdt_reset();
	_delay_ms(2000);
	uart_init_withdivider(1,25); //25 for 38400 on 16Mhz
	uart_send_string(1,"\r\n$PSTMSETPAR,1103,01*\r\n");_delay_ms(10);
	uart_send_string(1,"\r\n$PSTMSETPAR,1130,30*\r\n");_delay_ms(10);
	uart_send_string(1,"\r\n$PSTMSETPAR,1201,0040*\r\n");_delay_ms(10);	
	uart_send_string(1,"\r\n$PSTMSETPAR,1303,0.1*\r\n");_delay_ms(10);	
	uart_send_string(1,"\r\n$PSTMSAVEPAR*\r\n");_delay_ms(200);
	gps_reset(0);
	wdt_reset();
}

void gps_ml8088_init()
{
	uart_disable(1);
	wdt_reset();
	gps_power(0);
	_delay_ms(2000);
	wdt_reset();
	gps_power(1);
	_delay_ms(50);
	gps_reset(0);
	
	_delay_ms(2000);
	uart_init_withdivider_x2(1,16); //16 for 112500 x2 on 16Mhz
	uart_send_string(1,"\r\n$PSTMSETPAR,1102,8*\r\n");_delay_ms(10);	uart_send_string(1,"\r\n$PSTMSAVEPAR*\r\n");_delay_ms(200);
	uart_send_string(1,"\r\n$PSTMSETPAR,1102,8*\r\n");_delay_ms(10);	uart_send_string(1,"\r\n$PSTMSAVEPAR*\r\n");_delay_ms(200);
	uart_send_string(1,"\r\n$PSTMSETPAR,1102,8*\r\n");_delay_ms(10);	uart_send_string(1,"\r\n$PSTMSAVEPAR*\r\n");_delay_ms(200);
	gps_reset(0);
	wdt_reset();
	_delay_ms(2000);
	uart_init_withdivider(1,25); //25 for 38400 on 16Mhz
	uart_send_string(1,"\r\n$PSTMSETPAR,1201,0001*\r\n");_delay_ms(10);
	uart_send_string(1,"\r\n$PSTMSETPAR,1201,0001*\r\n");_delay_ms(10);
	uart_send_string(1,"\r\n$PSTMSETPAR,1303,0.5*\r\n");_delay_ms(10);
	uart_send_string(1,"\r\n$PSTMSETPAR,1303,0.5*\r\n");_delay_ms(10);
	uart_send_string(1,"\r\n$PSTMSAVEPAR*\r\n");_delay_ms(200);
	uart_send_string(1,"\r\n$PSTMSAVEPAR*\r\n");_delay_ms(200);
	gps_reset(0);
	wdt_reset();
}

#endif /* GPS_ML8088_H_ */