export const formatDate = (dateString: string): string => {
    const date = new Date(dateString);
    const options: Intl.DateTimeFormatOptions = {
      weekday: 'short',
      day: '2-digit',
      month: 'long',
      year: 'numeric', // Explicitly include the year
    };
    return new Intl.DateTimeFormat('en-GB', options).format(date);
};