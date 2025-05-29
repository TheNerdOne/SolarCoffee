import axios, { type Method, type AxiosResponse } from 'axios'
import type { AxiosError } from 'axios'
import { BASE_URL } from '../../config/services'

export async function makeRequest<T>(
    method: Method,
    endpoint: string,
    data?: unknown
): Promise<T> {
    try {
        const response: AxiosResponse<T> = await axios({
            method,
            url: `${BASE_URL}${endpoint}`,
            data,
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json',
            }
        })
        return response.data.data
    } catch (error: AxiosError | unknown) {
        if (axios.isAxiosError(error)) {
            throw new Error(error.response?.data?.message || error.message)
        }
        throw new Error('An unexpected error occurred')
    }
}